using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
	#region Consts

	private const string IgnoreCollisionsLayer = "Ignore Collisions";

	private const string PlayerLayer = "Player";

	#endregion

	#region Editor Variables

	[Header("GameObjects")]
	[SerializeField]
	private Rigidbody2D _rigidbody;

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
	private float _respawnDelay = 3f;

	[SerializeField]
	private float _respawnInvulnerability = 3f;    

	#endregion

	#region Variables

	private int _currentUpgradeCount;
	private EngineMode _engineMode;
	private Engine _engine;
	private WarpDrive _warpDrive;

	#endregion

	#region Properties

	public float RespawnDelay => _respawnDelay;

	private Bounds _screenBounds;
	public int CurrentUpgradeCount => _currentUpgradeCount;

	#endregion

	#region Events

	public event WeaponSystem.FireRateUpdatedEventHander FireRateUpdatedEvent;
	private void FireFireRateUpdatedEvent(FireRate newFireRate)
	{
		_currentUpgradeCount++;
		FireRateUpdatedEvent?.Invoke(newFireRate);
	}

	public delegate void UpgradeEngineModeEventHandler(EngineMode newEngineMode);
	public event UpgradeEngineModeEventHandler UpgradeEngineModeEvent;
	private void FireUpgradeEngineModeEvent()
	{
		_currentUpgradeCount++;
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

	private void OnEnable()
	{
		gameObject.layer = LayerMask.NameToLayer(IgnoreCollisionsLayer);
		Invoke(nameof(TurnOnCollisions), _respawnInvulnerability);
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
		transform.position = Vector3.zero;

		_engine = new StandardEngine(transform, _rigidbody);
		_engineMode = EngineMode.Standard;
		FireUpgradeEngineModeEvent();

		_weaponSystem.Initialize();

		if(_warpDrive != null)
		{
			_warpDrive.Deinitialize();
			_warpDrive = null;
		}

		_currentUpgradeCount = 0;
		gameObject.SetActive(true);
	}

	#endregion

	#region Private Methods

	private void TurnOnCollisions()
	{
		gameObject.layer = LayerMask.NameToLayer(PlayerLayer);
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

	private void UpgradeEngine()
	{
		if(_engine is StandardEngine)
		{
			_engine.Deinitialize();
			_engine = new DecoupledEngine(_rigidbody);
			_engineMode |= EngineMode.Decoupled;
			FireUpgradeEngineModeEvent();
		}
	}

	private void ActivateWarpDrive()
	{
		if(_warpDrive == null)
		{
			_warpDrive = new WarpDrive(transform, _targetingIcon);
			_engineMode |= EngineMode.Warp;
			FireUpgradeEngineModeEvent();
		}
	}

	private void PlayerDeath()
	{
		_rigidbody.velocity = Vector3.zero;
		_rigidbody.angularVelocity = 0f;
		gameObject.SetActive(false);

		_gameManager.PlayerDeath();
	}

	private void HandleDualBarrelsUpgraded(bool dualShotEnabled)
	{
		if(dualShotEnabled)
		{
			_currentUpgradeCount++;
		}
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
