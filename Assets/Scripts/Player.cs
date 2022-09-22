using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
	#region Editor Variables

	[Header("GameObjects")]
	[SerializeField]
	private Camera _mainCamera;

	[SerializeField]
	private Rigidbody2D _rigidbody;
	
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
	}

	private void OnEnable()
	{
		// Turn off collisions for a few seconds after spawning to ensure the
		// player has enough time to safely move away from asteroids
		gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
		Invoke(nameof(TurnOnCollisions), _respawnInvulnerability);
	}

	private void Update()
	{
		_thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			_turnDirection = 1f;
		} else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			_turnDirection = -1f;
		} else {
			_turnDirection = 0f;
		}

		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			Shoot();
		}
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
		if (_rigidbody.position.x > _screenBounds.max.x + 0.5f) {
			_rigidbody.position = new Vector2(_screenBounds.min.x - 0.5f, _rigidbody.position.y);
		} else if (_rigidbody.position.x < _screenBounds.min.x - 0.5f) {
			_rigidbody.position = new Vector2(_screenBounds.max.x + 0.5f, _rigidbody.position.y);
		} else if (_rigidbody.position.y > _screenBounds.max.y + 0.5f) {
			_rigidbody.position = new Vector2(_rigidbody.position.x, _screenBounds.min.y - 0.5f);
		} else if (_rigidbody.position.y < _screenBounds.min.y - 0.5f) {
			_rigidbody.position = new Vector2(_rigidbody.position.x, _screenBounds.max.y + 0.5f);
		}
	}

	#endregion

	#region Private Methods

	private void Shoot()
	{
		Bullet bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
		bullet.Project(transform.up);
	}

	private void TurnOnCollisions()
	{
		gameObject.layer = LayerMask.NameToLayer("Player");
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Asteroid"))
		{
			_rigidbody.velocity = Vector3.zero;
			_rigidbody.angularVelocity = 0f;
			gameObject.SetActive(false);

			FindObjectOfType<GameManager>().PlayerDeath(this);
		}
	}

	#endregion
}
