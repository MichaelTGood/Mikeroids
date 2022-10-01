using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
	#region Consts

	private const string IgnoreCollisionsLayer = "Ignore Collisions";
	private const string PlayerLayer = "Player";

	private const string SpawnTweenId = "PlayerSpawn";
	private const string NextLevelTweenId = "PlayerNextLevel";

	private const int UpgradeLimitToNextLevel = 2;

	#endregion

	#region Editor Variables

	[Header("GameObjects")]
	[SerializeField]
	private Rigidbody2D _rigidbody;

	[SerializeField]
	private SFXManager _sfxManager;

	[SerializeField]
	private SpriteRenderer _spriteRenderer;

	[SerializeField]
	private Transform _targetingIcon;

	[SerializeField]
	private WeaponSystem _weaponSystem;

	[SerializeField]
	private GameManager _gameManager;

	[SerializeField]
	private Camera _mainCamera;

	[Header("Respawn")]
	[SerializeField]
	private Color _defaultColor;

	[SerializeField]
	private float _respawnDelay = 3f;

	[SerializeField]
	private float _respawnInvulnerability = 3f;

	[SerializeField]
	private float _respawnFlickerTime = 3;

	[SerializeField]
	private Gradient _respawnGradient;

	[SerializeField]
	private float _upgradeFlickerTime = 0.5f;

	[SerializeField]
	private Gradient _upgradeGradient;

	#endregion

	#region Variables

	private Bounds _screenBounds;
	private int _currentUpgradeCount;
	private bool _playerNextLevel;
	private EngineMode _engineMode;
	private Engine _engine;
	private WarpDrive _warpDrive;
	private Sequence _spawnSequence;
	private Sequence _nextLevelSequence;

	#endregion

	#region Properties

	public float RespawnDelay => _respawnDelay;

	private int CurrentUpgradeCount
	{
		get => _currentUpgradeCount;
		set
		{
			_currentUpgradeCount = value;

			if(!_playerNextLevel && _currentUpgradeCount > UpgradeLimitToNextLevel)
			{
				_playerNextLevel = true;
				AnimatePlayerNextLevel();
				FirePlayerNextLevelEvent();
			}
			else if(_playerNextLevel && value == 0)
			{
				_playerNextLevel = false;
				DOTween.Kill(NextLevelTweenId);
				FirePlayerNextLevelEvent();
			}
		}
	}

	#endregion

	#region Events

	public delegate void PlayerNextLevelEventHandler(bool isPlayerNextLevel);
	public event PlayerNextLevelEventHandler PlayerNextLevelEvent;
	private void FirePlayerNextLevelEvent()
	{
		PlayerNextLevelEvent?.Invoke(_playerNextLevel);
	}

	public event WeaponSystem.FireRateUpdatedEventHander FireRateUpdatedEvent;
	private void FireFireRateUpdatedEvent(FireRate newFireRate)
	{
		CurrentUpgradeCount++;
		FireRateUpdatedEvent?.Invoke(newFireRate);
	}

	public delegate void UpgradeEngineModeEventHandler(EngineMode newEngineMode);
	public event UpgradeEngineModeEventHandler UpgradeEngineModeEvent;
	private void FireUpgradeEngineModeEvent()
	{
		CurrentUpgradeCount++;
		UpgradeEngineModeEvent?.Invoke(_engineMode);
	}

	#endregion

	#region Lifecycle

	private void Awake()
	{
		_screenBounds = new Bounds();
		_screenBounds.Encapsulate(_mainCamera.ScreenToWorldPoint(Vector3.zero));
		_screenBounds.Encapsulate(_mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f)));

		_weaponSystem.FireRateUpdatedEvent += FireFireRateUpdatedEvent;
		_weaponSystem.DualBarrelsUpdatedEvent += HandleDualBarrelsUpgraded;
	}

	private void OnDestroy()
	{
		_weaponSystem.FireRateUpdatedEvent -= FireFireRateUpdatedEvent;
		_weaponSystem.DualBarrelsUpdatedEvent -= HandleDualBarrelsUpgraded;
	}

	private void FixedUpdate()
	{
		_engine.FixedUpdate();

		// Wrap to the other side of the screen if the player goes off screen
		if (_rigidbody.position.x > _screenBounds.max.x + 0.5f)
		{
			_rigidbody.position = new Vector2(_screenBounds.min.x - 0.5f, _rigidbody.position.y);
		}
		else if(_rigidbody.position.x < _screenBounds.min.x - 0.5f)
		{
			_rigidbody.position = new Vector2(_screenBounds.max.x + 0.5f, _rigidbody.position.y);
		}
		else if(_rigidbody.position.y > _screenBounds.max.y + 0.5f)
		{
			_rigidbody.position = new Vector2(_rigidbody.position.x, _screenBounds.min.y - 0.5f);
		}
		else if(_rigidbody.position.y < _screenBounds.min.y - 0.5f)
		{
			_rigidbody.position = new Vector2(_rigidbody.position.x, _screenBounds.max.y + 0.5f);
		}
	}

	#endregion

	#region Public Methods

	public void Spawn()
	{
		gameObject.layer = LayerMask.NameToLayer(IgnoreCollisionsLayer);
		transform.position = Vector3.zero;

		ResetEngineMode();
		_weaponSystem.Initialize();
		CurrentUpgradeCount = 0;

		gameObject.SetActive(true);
		SpawnAnimation();
	}

	#endregion

	#region Private Methods

	private void SpawnAnimation()
	{
		DOTween.Kill(SpawnTweenId);
		_spawnSequence = DOTween.Sequence().SetId(SpawnTweenId);
		_spawnSequence.Append(_spriteRenderer.DOGradientColor(_respawnGradient, _respawnFlickerTime).SetLoops(int.MaxValue, LoopType.Yoyo));
		_spawnSequence.InsertCallback(_respawnInvulnerability, TurnOnCollision);

		void TurnOnCollision()
		{
			DOTween.Kill(SpawnTweenId);
			_spriteRenderer.DOColor(_defaultColor, _respawnFlickerTime).SetId(SpawnTweenId);
			gameObject.layer = LayerMask.NameToLayer(PlayerLayer);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.TryGetComponent(out Asteroid asteroid))
		{
			PlayerDeath();
		}
	}

	private void OnTriggerEnter2D(Collider2D trigger)
	{
		if(trigger.TryGetComponent(out UpgradeView upgradeView))
		{
			HandleUpgrade(upgradeView.Upgrade);
			
			Destroy(trigger.gameObject);
		}
		else if(trigger.TryGetComponent(out Lightning lightning))
		{
			PlayerDeath();
		}
	}

	private void HandleUpgrade(Upgrade upgrade)
	{
		switch(upgrade.UpgradeType)
		{
			case UpgradeTypes.Ship:
				if(upgrade.ShipUpgradeType == ShipUpgradeTypes.Decouple && !_engineMode.HasFlag(EngineMode.Decoupled))
				{
					UpgradeEngine();
				}
				else if(upgrade.ShipUpgradeType == ShipUpgradeTypes.Warp && !_engineMode.HasFlag(EngineMode.Warp))
				{
					ActivateWarpDrive();
				}
				break;
				
			case UpgradeTypes.Weapon:
				_weaponSystem.Upgrade(upgrade.WeaponUpgradeType);
				break;
		}
	}

	private void AnimatePlayerNextLevel()
	{
		DOTween.Kill(NextLevelTweenId);

		_nextLevelSequence = DOTween.Sequence().SetId(NextLevelTweenId).SetLoops(-1, LoopType.Yoyo);
		_nextLevelSequence.Append(_spriteRenderer.DOGradientColor(_upgradeGradient, _upgradeFlickerTime));
	}

	private void UpgradeEngine()
	{
		if(_engine is StandardEngine)
		{
			_engine.Deinitialize();
			_engine = new DecoupledEngine(_rigidbody);
			_engineMode |= EngineMode.Decoupled;
			_sfxManager.PlaySFX(AudioClips.Decoupled);
			FireUpgradeEngineModeEvent();
		}
	}

	private void ResetEngineMode()
	{
		_engine = new StandardEngine(transform, _rigidbody);

		DeactivateWarpDrive();

		_engineMode = EngineMode.Standard;

		FireUpgradeEngineModeEvent();
	}

	private void ActivateWarpDrive()
	{
		if(_warpDrive == null)
		{
			_warpDrive = new WarpDrive(transform, _targetingIcon);
			_engineMode |= EngineMode.Warp;
			_sfxManager.PlaySFX(AudioClips.Warp);
			FireUpgradeEngineModeEvent();
		}
	}

	private void DeactivateWarpDrive()
	{
		if(_warpDrive != null)
		{
			_warpDrive.Deinitialize();
			_warpDrive = null;
		}
	}

	private void HandleDualBarrelsUpgraded(bool dualShotEnabled)
	{
		if(dualShotEnabled)
		{
			CurrentUpgradeCount++;
		}
	}

	private void PlayerDeath()
	{
		_rigidbody.velocity = Vector3.zero;
		_rigidbody.angularVelocity = 0f;
		gameObject.SetActive(false);

		_gameManager.PlayerDeath();
	}

	#endregion

	#region Cheater

	[ContextMenu("Switch to Decoupled Mode")]
	private void CheaterSwitchToDecoupledMode()
	{
		UpgradeEngine();
		FireUpgradeEngineModeEvent();
	}

	[ContextMenu("Activate WarpDrive")]
	private void CheaterActivateWarpDrive()
	{
		ActivateWarpDrive();
		FireUpgradeEngineModeEvent();
	}

	[ContextMenu("Log Engine Mode")]
	private void CheaterLogEngineMode()
	{
		Debug.Log(_engineMode);
	}
	#endregion
}
