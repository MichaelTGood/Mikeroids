using UnityEngine;
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

	#region Lifecycle

	private void Start()
	{
		NewGame();
	}

	private void OnEnable()
	{
		InputManager.Menu.Enter.started += _ => NewGame();
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

	public void PlayerDeath(Player player)
	{
		_explosionEffect.transform.position = player.transform.position;
		_explosionEffect.Play();

		SetLives(_lives - 1);

		if (_lives <= 0)
		{
			GameOver();
		}
		else
		{
			Invoke(nameof(Respawn), player.RespawnDelay);
		}
	}

	#endregion

	#region Private Methods

	private void NewGame()
	{
		Asteroid[] asteroids = FindObjectsOfType<Asteroid>();

		for(int i = 0; i < asteroids.Length; i++)
		{
			Destroy(asteroids[i].gameObject);
		}

		_gameOverUI.SetActive(false);

		SetScore(0);
		SetLives(3);
		Respawn();
	}

	private void Respawn()
	{
		_player.transform.position = Vector3.zero;
		_player.gameObject.SetActive(true);
		InputManager.SwitchToActionMap(InputManager.ShipStandard);
	}

	private void GameOver()
	{
		_gameOverUI.SetActive(true);
		InputManager.SwitchToActionMap(InputManager.Menu);
	}

	private void SetScore(int score)
	{
		_score = score;
		_scoreText.text = score.ToString();
	}

	private void SetLives(int lives)
	{
		_lives = lives;
		_livesText.text = lives.ToString();
	}

	#endregion
}
