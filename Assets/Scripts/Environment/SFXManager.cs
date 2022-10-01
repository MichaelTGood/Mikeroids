using System.Collections.Generic;
using UnityEngine;

	public class SFXManager : MonoBehaviour
	{
		#region Editor Variables

		[SerializeField]
		private AudioSource _audioSource;
		
		[Header("Audio Clips")]
		[SerializeField]
		private AudioClip _shotFiredClip;

		[SerializeField]
		private AudioClip _upgradeFireRateClip;

		[SerializeField]
		private AudioClip _upgradeDualShotClip;

		[SerializeField]
		private AudioClip _upgradeDecoupledClip;

		[SerializeField]
		private AudioClip _upgradeWarpClip;
		
		#endregion

		#region Variables

		private Dictionary<AudioClips, AudioClip> _audioClips;

		#endregion

		private void Awake()
		{
			_audioClips = new Dictionary<AudioClips, AudioClip>()
			{
				[AudioClips.ShotFired] = _shotFiredClip,
				[AudioClips.FireRate] = _upgradeFireRateClip,
				[AudioClips.DualShot] = _upgradeDualShotClip,
				[AudioClips.Decoupled] = _upgradeDecoupledClip,
				[AudioClips.Warp] = _upgradeWarpClip,
			};
		}

		public void PlaySFX(AudioClips audioClip)
		{
			_audioSource.PlayOneShot(_audioClips[audioClip]);
		}
	}
