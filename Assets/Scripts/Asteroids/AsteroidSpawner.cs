using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
	#region Editor Variables

	[SerializeField]
	private GameManager _gameManager;

	[SerializeField]
	private Asteroid _asteroidPrefab;

	[SerializeField]
	private float _spawnDistance = 12f;

	[SerializeField]
	private float _spawnRate = 1f;

	[SerializeField]
	private int _amountPerSpawn = 1;

	[SerializeField, Range(0f, 45f)]
	private float _trajectoryVariance = 15f;

	#endregion

	private void Start()
	{
		InvokeRepeating(nameof(Spawn), _spawnRate, _spawnRate);
	}

	public void Spawn()
	{
		for (int i = 0; i < _amountPerSpawn; i++)
		{
			// Choose a random direction from the center of the spawner and
			// spawn the asteroid a distance away
			Vector2 spawnDirection = Random.insideUnitCircle.normalized;
			Vector3 spawnPoint = spawnDirection * _spawnDistance;

			// Offset the spawn point by the position of the spawner so its
			// relative to the spawner location
			spawnPoint += transform.position;

			// Calculate a random variance in the asteroid's rotation which will
			// cause its trajectory to change
			float variance = Random.Range(-_trajectoryVariance, _trajectoryVariance);
			Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

			// Create the new asteroid by cloning the prefab and set a random
			// size within the range
			Asteroid asteroid = Instantiate(_asteroidPrefab, spawnPoint, rotation);
			Vector2 trajectory = rotation * -spawnDirection;
			asteroid.Initialize(_gameManager, trajectory);
		}
	}
}
