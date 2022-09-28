using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Asteroid : MonoBehaviour
{
	#region Editor Variables

	[Header("Game Objects")]
	[SerializeField]
	private Rigidbody2D _rigidbody;

	[SerializeField]
	private SpriteRenderer _spriteRenderer;

	[SerializeField]
	private UpgradeView _upgradePrefab;

	[SerializeField]
	private Sprite[] _sprites;

	[Header("Asteroid Settings")]
	[SerializeField]
	private float _size = 1f;

	[SerializeField]
	private float _minSize = 0.35f;

	[SerializeField]
	private float _maxSize = 1.65f;

	[SerializeField]
	private float _movementSpeed = 50f;

	[SerializeField]
	private float _maxLifetime = 30f;

	[Header("Other Settings")]
	[SerializeField, Range(0,1)]
	private float _upgradeChance = 0.33f;

	#endregion

	#region Properties

	public float Size => _size;

	#endregion

	#region Lifecycle

	private void Start()
	{
		// Assign random properties to make each asteroid feel unique
		_spriteRenderer.sprite = _sprites[Random.Range(0, _sprites.Length)];
		transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);

		// Set the scale and mass of the asteroid based on the assigned size so
		// the physics is more realistic
		transform.localScale = Vector3.one * _size;
		_rigidbody.mass = _size;

		// Destroy the asteroid after it reaches its max lifetime
		Destroy(gameObject, _maxLifetime);
	}

	#endregion

	#region Public Methods

	public void SetRandomSize()
	{
		_size = Random.Range(_minSize, _maxSize);
	}

	public void SetTrajectory(Vector2 direction)
	{
		// The asteroid only needs a force to be added once since they have no
		// drag to make them stop moving
		_rigidbody.AddForce(direction * _movementSpeed);
	}

	#endregion

	#region Private Methods

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.TryGetComponent(out Bullet bullet))
		{
			// Check if the asteroid is large enough to split in half
			// (both parts must be greater than the minimum size)
			if ((_size * 0.5f) >= _minSize)
			{
				CreateSplit();

				if(Random.value <= _upgradeChance)
				{
					CreateUpgrade();
				}
				else
				{
					CreateSplit();
				}
			}

			FindObjectOfType<GameManager>().AsteroidDestroyed(this);

			// Destroy the current asteroid since it is either replaced by two
			// new asteroids or small enough to be destroyed by the bullet
			Destroy(gameObject);
		}
	}

	private Asteroid CreateSplit()
	{
		// Set the new asteroid poistion to be the same as the current asteroid
		// but with a slight offset so they do not spawn inside each other
		Vector2 position = transform.position;
		position += Random.insideUnitCircle * 0.5f;

		// Create the new asteroid at half the size of the current
		Asteroid half = Instantiate(this, position, transform.rotation);
		half._size = _size * 0.5f;

		// Set a random trajectory
		half.SetTrajectory(Random.insideUnitCircle.normalized);

		return half;
	}

	private UpgradeView CreateUpgrade()
	{
		// Set the new asteroid poistion to be the same as the current asteroid
		// but with a slight offset so they do not spawn inside each other
		Vector2 position = transform.position;
		position += Random.insideUnitCircle * 0.5f;

		// Create the new asteroid at half the size of the current
		UpgradeView upgrade = Instantiate(_upgradePrefab, position, transform.rotation);

		// Set a random trajectory
		upgrade.SetTrajectory(Random.insideUnitCircle.normalized);

		return upgrade;
	}

	#endregion
}
