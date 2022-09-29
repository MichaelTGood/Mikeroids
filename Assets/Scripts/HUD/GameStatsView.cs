using TMPro;
using UnityEngine;

	public class GameStatsView : MonoBehaviour
	{
		#region Editor Variables

		[SerializeField]
		private TextMeshProUGUI _livesText;

		[SerializeField]
		private TextMeshProUGUI _scoreText;

		#endregion

		public void SetScore(int newScore)
		{
			_scoreText.text = newScore.ToString();
		}

		public void SetLives(int newLives)
		{
			_livesText.text = newLives.ToString();
		}



	}
