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

	private Engine _engine;
	private WarpDrive _warpDrive;

	#endregion

	#region Properties

	public float RespawnDelay => _respawnDelay;

	private Bounds _screenBounds;

	#endregion

	#region Lifecycle

	private void Awake()
	{
		_screenBounds = new Bounds();
		_screenBounds.Encapsulate(_mainCamera.ScreenToWorldPoint(Vector3.zero));
		_screenBounds.Encapsulate(_mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f)));

		Spawn();
	}

	private void OnEnable()
	{
		gameObject.layer = LayerMask.NameToLayer(IgnoreCollisionsLayer);
		Invoke(nameof(TurnOnCollisions), _respawnInvulnerability);
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

		_weaponSystem.Initialize();

		if(_warpDrive != null)
		{
			_warpDrive.Deinitialize();
			_warpDrive = null;
		}

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
			_rigidbody.velocity = Vector3.zero;
			_rigidbody.angularVelocity = 0f;
			gameObject.SetActive(false);

			_gameManager.PlayerDeath();
		}
	}

	private void OnTriggerEnter2D(Collider2D trigger)
	{
		if(trigger.TryGetComponent(out UpgradeView upgradeView))
		{
			HandleUpgrade(upgradeView.Upgrade);
			
			Destroy(trigger.gameObject);
		}
	}

	private void HandleUpgrade(Upgrade upgrade)
	{
		switch(upgrade.UpgradeType)
		{
			case UpgradeTypes.Ship:
				if(upgrade.ShipUpgradeType == ShipUpgradeTypes.Decouple)
				{
					UpgradeEngine();
				}
				else
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
		}
	}

	private void ActivateWarpDrive()
	{
		if(_warpDrive == null)
		{
			_warpDrive = new WarpDrive(transform, _targetingIcon);
		}
	}

	#endregion

	#region Cheater

	[ContextMenu("Switch to Decoupled Mode")]
	private void CheaterSwitchToDecoupledMode()
	{
		UpgradeEngine();
	}

	[ContextMenu("Activate WarpDrive")]
	private void CheaterActivateWarpDrive()
	{
		ActivateWarpDrive();
	}

	#endregion
}
