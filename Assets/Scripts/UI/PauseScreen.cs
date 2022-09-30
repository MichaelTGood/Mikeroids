using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
	#region Consts

	private const string TweenId = "PauseScreenOutline";
	private const float OutlineMinimumAlpha = 0.25f;
	private const float OutlineTweenTime = 1f;

	#endregion

	#region Editor Variables

	[SerializeField]
	private GameObject _content;

	[SerializeField]
	private Button _continueButton;

	[SerializeField]
	private Outline _outline;

	#endregion

	#region Variables

	private Sequence _sequence;
	private Action<bool> _shouldQuitCallback;

	#endregion

	public void TogglePause(bool pause, Action<bool> shouldQuitCallback = null)
	{
		_content.SetActive(pause);
		_shouldQuitCallback = shouldQuitCallback;

		if(pause)
		{
			_continueButton.Select();

			KillTween();

			_sequence = DOTween.Sequence().SetId(TweenId).SetLoops(-1, LoopType.Yoyo);
			_sequence.timeScale = 1;
			_sequence.Append(_outline.DOFade(OutlineMinimumAlpha, OutlineTweenTime));
		}
	}

	public void OnContinue()
	{
		KillTween();
		_shouldQuitCallback?.Invoke(false);
	}

	public void OnQuit()
	{
		KillTween();
		_shouldQuitCallback?.Invoke(true);
	}

	private static void KillTween()
	{
		if(DOTween.IsTweening(TweenId))
		{
			DOTween.Kill(TweenId);
		}
	}
}
