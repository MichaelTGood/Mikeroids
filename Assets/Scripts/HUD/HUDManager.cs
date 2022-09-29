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

		[SerializeField]
		private EngineModeView _engineModeView;

		#endregion

		private void Awake()
		{
			_gameManager.ScoreUpdatedEvent += _gameStatsView.SetScore;
			_gameManager.LivesUpdatedEvent += _gameStatsView.SetLives;

			_gameManager.FireRateUpdatedEvent += _fireRateView.UpdateFireRate;
			_gameManager.UpgradeEngineModeEvent += _engineModeView.UpdateEngineMode;
		}

		private void OnDestroy()
		{
			_gameManager.ScoreUpdatedEvent -= _gameStatsView.SetScore;
			_gameManager.LivesUpdatedEvent -= _gameStatsView.SetLives;

			_gameManager.FireRateUpdatedEvent -= _fireRateView.UpdateFireRate;
			_gameManager.UpgradeEngineModeEvent -= _engineModeView.UpdateEngineMode;
		}
	}
