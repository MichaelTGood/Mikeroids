using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	#region Editor Variables

	[SerializeField]
	private Player _player;

	[SerializeField]
	private ParticleSystem _explosionEffect;

	[SerializeField]
	private GameObject _gameOverUI;

	[SerializeField]
	private Text _scoreText;

	[SerializeField]
	private Text _livesText;

	#endregion

	#region Variables

	private int _score;

	private int _lives;

	#endregion

	#region Events

	public delegate void ScoreUpdatedEventHander(int newScore);
	public event ScoreUpdatedEventHander ScoreUpdatedEvent;
	private void FireScoreUpdatedEvent(int newScore)
	{
		ScoreUpdatedEvent?.Invoke(newScore);
	}

	public delegate void LivesUpdatedEventHander(int newLives);
	public event LivesUpdatedEventHander LivesUpdatedEvent;
	private void FireLivesUpdatedEvent(int newLives)
	{
		LivesUpdatedEvent?.Invoke(newLives);
	}
	
	public event WeaponSystem.FireRateUpdatedEventHander FireRateUpdatedEvent;
	private void FireFireRateUpdatedEvent(FireRate newFireRate)
	{
		FireRateUpdatedEvent?.Invoke(newFireRate);
	}
	
	public event Player.UpgradeEngineModeEventHandler UpgradeEngineModeEvent;
	private void FireUpgradeEngineModeEvent(EngineMode newEngineMode)
	{
		UpgradeEngineModeEvent?.Invoke(newEngineMode);
	}

	#endregion

	#region Lifecycle

	private void Awake()
	{
		InputManager.Quit.Quit.Enable();
		InputManager.Quit.Quit.started += Quit;
	}

	private void Start()
	{
		NewGame();
	}

	private void OnEnable()
	{
		InputManager.Menu.Enter.started += NewGame;

		_player.FireRateUpdatedEvent += FireFireRateUpdatedEvent;
		_player.UpgradeEngineModeEvent += FireUpgradeEngineModeEvent;
	}

	private void OnDisable()
	{
		InputManager.Menu.Enter.started -= NewGame;

		_player.FireRateUpdatedEvent -= FireFireRateUpdatedEvent;
		_player.UpgradeEngineModeEvent -= FireUpgradeEngineModeEvent;
	}

	#endregion

	#region Public Methods

	public void AsteroidDestroyed(Asteroid asteroid)
	{
		_explosionEffect.transform.position = asteroid.transform.position;
		_explosionEffect.Play();

		if (asteroid.Size < 0.7f)		// small asteroid
		{
			SetScore(_score + 100);
		}
		else if (asteroid.Size < 1.4f)	// medium asteroid
		{
			SetScore(_score + 50);
		}
		else							// large asteroid
		{
			SetScore(_score + 25);
		}
	}

	public void PlayerDeath()
	{
		_explosionEffect.transform.position = _player.transform.position;
		_explosionEffect.Play();

		SetLives(_lives - 1);

		if (_lives <= 0)
		{
			GameOver();
		}
		else
		{
			Invoke(nameof(Respawn), _player.RespawnDelay);
		}
	}

	#endregion

	#region Private Methods

	private void NewGame(InputAction.CallbackContext _) => NewGame();

	private void NewGame()
	{
		InputManager.Menu.Disable();

		DestroyAllOfType<Asteroid>();
		DestroyAllOfType<UpgradeView>();

		_gameOverUI.SetActive(false);

		SetScore(0);
		SetLives(3);
		Respawn();
	}

	private void DestroyAllOfType<T>()
		where T : MonoBehaviour
	{
		T[] objects = FindObjectsOfType<T>();

		for(int i = 0; i < objects.Length; i++)
		{
			Destroy(objects[i].gameObject);
		}
	}

	private void Respawn()
	{
		_player.Spawn();
	}

	private void GameOver()
	{
		_gameOverUI.SetActive(true);
		InputManager.SwitchToMenuInputMap();
	}

	private void SetScore(int score)
	{
		_score = score;
		FireScoreUpdatedEvent(_score);
	}

	private void SetLives(int lives)
	{
		_lives = lives;
		FireLivesUpdatedEvent(lives);
	}

	private void Quit(InputAction.CallbackContext ctx)
	{
		Application.Quit();
	}

	#endregion

}
