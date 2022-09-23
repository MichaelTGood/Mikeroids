using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
	#region Consts

	private const string IgnoreCollisionsLayer = "Ignore Collisions";

	private const string PlayerLayer = "Player";

	private const float InputThreshold = 0.15f;

	#endregion

	#region Editor Variables

	[Header("GameObjects")]
	[SerializeField]
	private Rigidbody2D _rigidbody;

	[SerializeField]
	private GameManager _gameManager;

	[SerializeField]
	private Camera _mainCamera;
	
	[SerializeField]
	private Bullet _bulletPrefab;

	[Header("Movement")]
	[SerializeField]
	private float _thrustSpeed = 1f;

	[SerializeField]
	private float _rotationSpeed = 0.1f;

	[Header("Respawn")]
	[SerializeField]
	private float _respawnDelay = 3f;

	[SerializeField]
	private float _respawnInvulnerability = 3f;    

	#endregion

	#region Variables

	private bool _thrusting;
	private float _turnDirection = 0f;
	private float _rotateInput;

	#endregion

	#region Properties

	public float RespawnDelay => _respawnDelay;

	private Bounds _screenBounds;

	#endregion

	#region Lifecycle

	private void Awake()
	{
		InputManager.SwitchToActionMap(InputManager.ShipStandard);

		_screenBounds = new Bounds();
		_screenBounds.Encapsulate(_mainCamera.ScreenToWorldPoint(Vector3.zero));
		_screenBounds.Encapsulate(_mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f)));
	}

	private void OnEnable()
	{
		// Turn off collisions for a few seconds after spawning to ensure the
		// player has enough time to safely move away from asteroids
		gameObject.layer = LayerMask.NameToLayer(IgnoreCollisionsLayer);
		Invoke(nameof(TurnOnCollisions), _respawnInvulnerability);

		HandleSubscriptions(true);
	}

	private void OnDisable()
	{
		HandleSubscriptions(false);
	}

	private void FixedUpdate()
	{
		if (_thrusting) {
			_rigidbody.AddForce(transform.up * _thrustSpeed);
		}

		if (_turnDirection != 0f) {
			_rigidbody.AddTorque(_rotationSpeed * _turnDirection);
		}

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

	#region Private Methods

	private void HandleSubscriptions(bool subscribe)
	{
		if(subscribe)
		{
			InputManager.ShipStandard.Forward.performed += OnMoveForward;
			InputManager.ShipStandard.Rotate.performed += OnRotate;
			InputManager.ShipStandard.Rotate.canceled += StopRotate;
			InputManager.ShipStandard.Fire.started += Shoot;
		}
		else
		{
			InputManager.ShipStandard.Forward.performed -= OnMoveForward;
			InputManager.ShipStandard.Rotate.performed -= OnRotate;
			InputManager.ShipStandard.Rotate.canceled -= StopRotate;
			InputManager.ShipStandard.Fire.started -= Shoot;
		}
	}

	private void OnMoveForward(InputAction.CallbackContext ctx)
	{
		_thrusting = ctx.ReadValue<float>() > InputThreshold;
	}

	private void OnRotate(InputAction.CallbackContext ctx)
	{
		_rotateInput = ctx.ReadValue<float>();

		if(Mathf.Abs(_rotateInput) < InputThreshold)
		{
			_turnDirection = 0;
		}

		_turnDirection = _rotateInput;
	}

	private void StopRotate(InputAction.CallbackContext ctx)
	{
		_turnDirection = 0;
	}

	private void Shoot(InputAction.CallbackContext ctx)
	{
		Bullet bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
		bullet.Project(transform.up);
	}

	private void TurnOnCollisions()
	{
		gameObject.layer = LayerMask.NameToLayer(PlayerLayer);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Asteroid"))
		{
			_rigidbody.velocity = Vector3.zero;
			_rigidbody.angularVelocity = 0f;
			gameObject.SetActive(false);

			_gameManager.PlayerDeath(this);
		}
	}

	#endregion
}
