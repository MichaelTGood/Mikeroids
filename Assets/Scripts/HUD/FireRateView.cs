using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireRateView : MonoBehaviour
{
	#region Consts

	private const int CylinderRotationZ = 90;
	private const int SingleRotation = 0;
	private const int BurstRotation = 120;
	private const int FullAutoRotation = 240;

	private const string TweenId = "FireRateRotation";
	private const float TweenRotationTime = 0.25f;

	#endregion

	#region Editor Variables

	[SerializeField]
	private Transform _fireRateCylinder;

	[SerializeField]
	private TextMeshPro _singleText;
	
	[SerializeField]
	private TextMeshPro _burstText;
	
	[SerializeField]
	private TextMeshPro _fullAutoText;

	#endregion

	#region Variables

	private Dictionary<FireRate, FireRateData> _fireRateData;
	private FireRate _currentFireRate;
	private Sequence _rotationSequence;

	#endregion

	private void Awake()
	{
		_fireRateData = new Dictionary<FireRate, FireRateData>()
		{
			{ FireRate.Single, new FireRateData(_singleText, SingleRotation)},
			{ FireRate.Burst, new FireRateData(_burstText, BurstRotation)},
			{ FireRate.FullAuto, new FireRateData(_fullAutoText, FullAutoRotation)},
		};

		foreach(KeyValuePair<FireRate, FireRateData> kvp in _fireRateData)
		{
			kvp.Value.TextObject.gameObject.SetActive(false);
		}

		_fireRateCylinder.rotation = Quaternion.Euler(new Vector3(0, 0, CylinderRotationZ));
	}

	public void UpdateFireRate(FireRate newFireRate)
	{
		FireRate previousFireRate = _currentFireRate;
		_currentFireRate = newFireRate;

		FireRateData currentFireRateData = _fireRateData[_currentFireRate];
		FireRateData previousFireRateData = _fireRateData[previousFireRate];
		
		currentFireRateData.TextObject.gameObject.SetActive(true);

		if(previousFireRate != _currentFireRate)
		{
			_rotationSequence = DOTween.Sequence().SetId(TweenId);
			_rotationSequence.Append(_fireRateCylinder.DORotate(
				new Vector3(currentFireRateData.RotationPositionX, 0, CylinderRotationZ),
				TweenRotationTime,
				RotateMode.FastBeyond360
				));

			_rotationSequence.Insert(0, currentFireRateData.TextObject.DOFade(1, TweenRotationTime / 2));
			_rotationSequence.Insert(TweenRotationTime / 2, previousFireRateData.TextObject.DOFade(0, TweenRotationTime / 2));
			_rotationSequence.AppendCallback(UpdateCurrentTextObject);
		}

		// Nested Class
		void UpdateCurrentTextObject()
		{
			_fireRateData[previousFireRate].TextObject.gameObject.SetActive(false);
		}
	}

	#region Nested Classes

	private class FireRateData
	{
		#region Variables

		private readonly TextMeshPro _textObject;

		private readonly int _rotationPositionX;

		#endregion

		#region Properties

		public TextMeshPro TextObject => _textObject;

		public int RotationPositionX => _rotationPositionX;

		#endregion

		public FireRateData(TextMeshPro textObject, int rotationPositionX)
		{
			_textObject = textObject;
			_rotationPositionX = rotationPositionX;
		}
	}

	#endregion

	#region Cheater

	[ContextMenu("Next FireRate")]
	private void CheaterNextFireRate()
	{
		if(_currentFireRate == FireRate.FullAuto)
		{
			UpdateFireRate(0);
		}
		else
		{
			UpdateFireRate(_currentFireRate + 1);
		}
	}

	#endregion
}
