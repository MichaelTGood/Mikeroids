using DG.Tweening;
using UnityEngine;

public class BGMComposer : MonoBehaviour
{
	#region Consts

	private const string TweenId = "AudioFade";
	private const float VolumeMax = 0.5f;
	private const float FadeTime = 0.25f;

	#endregion

	#region Editor Variables

	[SerializeField]
	private GameManager _gameManager;

	[SerializeField]
	private AudioSource _bgm1;

	[SerializeField]
	private AudioSource _bgm2;

	#endregion

	#region Varaibles

	private Sequence _sequence;
	private AudioSource _currentAudioSource;

	#endregion

	#region Lifecycle

	private void Start()
	{
		_bgm1.Play();
		_bgm2.Play();
		CrossFade(_bgm1);

		_gameManager.PauseEvent += AdjustForPauseScreen;
	}

	private void Update()
	{
		if(_gameManager.MaySpawnLightning && _currentAudioSource == _bgm1)
		{
			CrossFade(_bgm2, _bgm1);
		}
		else if(!_gameManager.MaySpawnLightning && _currentAudioSource == _bgm2)
		{
			CrossFade(_bgm1, _bgm2, true);
		}
	}

	#endregion

	#region Private Methods

	private void CrossFade(AudioSource toAudio, AudioSource fromAudio = null, bool quickFade = false)
	{
		if(DOTween.IsTweening(TweenId))
		{
			DOTween.Kill(TweenId);
		}

		_currentAudioSource = toAudio;

		float fadeTime = quickFade ? FadeTime / 2 : FadeTime;

		_sequence = DOTween.Sequence().SetId(TweenId);
		_sequence.Insert(0, toAudio.DOFade(VolumeMax, fadeTime));
		if(fromAudio != null)
		{
			_sequence.Insert(0, fromAudio.DOFade(0, fadeTime));
		}
	}

	private void AdjustForPauseScreen(bool isPaused)
	{
		if(DOTween.IsTweening(TweenId))
		{
			DOTween.Kill(TweenId);
		}

		float newVolume = isPaused ? VolumeMax / 3 : VolumeMax;

		_sequence = DOTween.Sequence().SetId(TweenId);
		_sequence.timeScale = 1;
		_sequence.Insert(0, _currentAudioSource.DOFade(newVolume, FadeTime * 2));
	}

	#endregion
}
