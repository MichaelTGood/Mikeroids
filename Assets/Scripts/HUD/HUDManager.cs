using UnityEngine;

	public class HUDManager : MonoBehaviour
	{
		#region Editor Variables

		[SerializeField]
		private GameManager _gameManager;
		
		[Header("HUD Views")]
		[SerializeField]
		private GameStatsView _gameStatsView;

		[SerializeField]
		private FireRateView _fireRateView;

		#endregion

		private void Awake()
		{
			_gameManager.ScoreUpdatedEvent += _gameStatsView.SetScore;
			_gameManager.LivesUpdatedEvent += _gameStatsView.SetLives;

			_gameManager.FireRateUpdatedEvent += _fireRateView.UpdateFireRate;
		}

		private void OnDestroy()
		{
			_gameManager.ScoreUpdatedEvent -= _gameStatsView.SetScore;
			_gameManager.LivesUpdatedEvent -= _gameStatsView.SetLives;

			_gameManager.FireRateUpdatedEvent -= _fireRateView.UpdateFireRate;
		}
	}
