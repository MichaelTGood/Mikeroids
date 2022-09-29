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

	#endregion

	private void Start()
	{
		_bgm1.Play();
		_bgm2.Play();
		_bgm1.DOFade(VolumeMax, FadeTime);
	}

	private void Update()
	{
		if(_gameManager.MaySpawnLightning && _bgm1.isPlaying)
		{
			CrossFade(_bgm2, _bgm1);
		}
		else if(!_gameManager.MaySpawnLightning && _bgm2.isPlaying)
		{
			CrossFade(_bgm1, _bgm2, true);
		}
	}

	private void CrossFade(AudioSource toAudio, AudioSource fromAudio, bool quickFade = false)
	{
		if(DOTween.IsTweening(TweenId))
		{
			DOTween.Kill(TweenId);
		}

		float fadeTime = quickFade ? FadeTime / 2 : FadeTime;

		_sequence = DOTween.Sequence().SetId(TweenId);
		_sequence.Insert(0, toAudio.DOFade(VolumeMax, fadeTime));
		_sequence.Insert(0,fromAudio.DOFade(0, fadeTime));
	}
}
