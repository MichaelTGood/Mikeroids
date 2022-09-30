using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EngineModeView : MonoBehaviour
{
	#region Consts

	private const int CylinderRotationZ = 90;
	private const int StandardRotation = 0;
	private const int DecoupledRotation = 90;
	private const int DecoupledWarpRotation = 180;
	private const int WarpRotation = 270;

	private const string TweenId = "EngineModeRotation";
	private const float TweenRotationTime = 0.25f;

	#endregion

	#region Editor Variables

	[SerializeField]
	private Transform _cylinder;

	[SerializeField]
	private TextMeshPro _standardText;
	
	[SerializeField]
	private TextMeshPro _decoupledText;
	
	[SerializeField]
	private TextMeshPro _decoupledWarpText;

	[SerializeField]
	private TextMeshPro _warpText;

	#endregion

	#region Variables

	private Dictionary<EngineMode, ViewData> _engineModeData;
	private EngineMode _currentEngineMode;
	private Sequence _rotationSequence;

	#endregion

	private void Awake()
	{
		_engineModeData = new Dictionary<EngineMode, ViewData>()
		{
			{ EngineMode.Standard, new ViewData(_standardText, StandardRotation)},
			{ EngineMode.Decoupled, new ViewData(_decoupledText, DecoupledRotation)},
			{ EngineMode.DecoupledWarp, new ViewData(_decoupledWarpText, DecoupledWarpRotation)},
			{ EngineMode.Warp, new ViewData(_warpText, WarpRotation)},
		};

		foreach(KeyValuePair<EngineMode, ViewData> kvp in _engineModeData)
		{
			kvp.Value.TextObject.gameObject.SetActive(false);
		}

		_cylinder.rotation = Quaternion.Euler(new Vector3(0, 0, CylinderRotationZ));
	}

	public void UpdateEngineMode(EngineMode newEngineMode)
	{
		EngineMode previousEngineMode = _currentEngineMode;
		_currentEngineMode = newEngineMode;

		ViewData currentViewData = _engineModeData[_currentEngineMode];
		ViewData previousViewData = _engineModeData[previousEngineMode];
		
		currentViewData.TextObject.gameObject.SetActive(true);

		if(previousEngineMode != _currentEngineMode)
		{
			_rotationSequence = DOTween.Sequence().SetId(TweenId);
			_rotationSequence.Append(_cylinder.DORotate(
				new Vector3(currentViewData.RotationPositionX, 0, CylinderRotationZ),
				TweenRotationTime,
				RotateMode.FastBeyond360
				));

			_rotationSequence.Insert(0, currentViewData.TextObject.DOFade(1, TweenRotationTime / 2));
			_rotationSequence.Insert(TweenRotationTime / 2, previousViewData.TextObject.DOFade(0, TweenRotationTime / 2));
			_rotationSequence.AppendCallback(UpdateCurrentTextObject);
		}

		// Nested Class
		void UpdateCurrentTextObject()
		{
			_engineModeData[previousEngineMode].TextObject.gameObject.SetActive(false);
		}
	}

	#region Nested Classes

	private class ViewData
	{
		#region Variables

		private readonly TextMeshPro _textObject;

		private readonly int _rotationPositionX;

		#endregion

		#region Properties

		public TextMeshPro TextObject => _textObject;

		public int RotationPositionX => _rotationPositionX;

		#endregion

		public ViewData(TextMeshPro textObject, int rotationPositionX)
		{
			_textObject = textObject;
			_rotationPositionX = rotationPositionX;
		}
	}

	#endregion

	#region Cheater

	[ContextMenu("Next EngineMode")]
	private void CheaterNextEngineMode()
	{
		switch(_currentEngineMode)
		{
			case EngineMode.Standard:
				UpdateEngineMode(EngineMode.Decoupled);
				break;

			case EngineMode.Decoupled:
			case EngineMode.Warp:
				UpdateEngineMode(EngineMode.DecoupledWarp);
				break;

			case EngineMode.DecoupledWarp:
				UpdateEngineMode(EngineMode.Standard);
				break;
		}
	}

	#endregion
}
