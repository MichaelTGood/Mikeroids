using UnityEngine;
using UnityEngine.InputSystem;

public class WarpDrive
{
	#region Consts

	private const int MinimumDistance = 2;
	private const int MaximumDistance = 10;

	#endregion

	#region Variables

	private readonly Transform _ship;
	private readonly Transform _targetingIcon;
	private Vector3 _warpPosition;

	private float _warpTargetingInput;
	private Vector3 _potentialWarpPosition;

	#endregion
	
	public WarpDrive(Transform ship, Transform targetingIcon)
	{
		_ship = ship;
		_targetingIcon = targetingIcon;

		HandleSubscriptions(true);
	}

	public void Deinitialize()
	{
		_targetingIcon.gameObject.SetActive(false);
		HandleSubscriptions(false);
	}

	#region Private Methods

	private void HandleSubscriptions(bool subscribe)
	{
		if(subscribe)
		{
			InputManager.WarpJump.Enable();
			InputManager.WarpJump.Warp.started += StartWarpTargeting;
			InputManager.WarpJump.Warp.canceled += Warp;
		}
		else
		{
			InputManager.WarpJump.Warp.started -= StartWarpTargeting;
			InputManager.WarpJump.Warp.canceled -= Warp;
			InputManager.WarpJump.WarpTargeting.performed -= WarpTargeting;
			InputManager.WarpJump.Disable();
		}
	}

	private void StartWarpTargeting(InputAction.CallbackContext ctx)
	{
		_targetingIcon.gameObject.SetActive(true);
		InputManager.WarpJump.WarpTargeting.performed += WarpTargeting;
	}

	private void Warp(InputAction.CallbackContext ctx)
	{
		_warpPosition = _targetingIcon.position;

		_targetingIcon.gameObject.SetActive(false);
		InputManager.WarpJump.WarpTargeting.performed -= WarpTargeting;

		_ship.position = _warpPosition;
	}

	private void WarpTargeting(InputAction.CallbackContext ctx)
	{
		_warpTargetingInput = ctx.ReadValue<float>();
		_potentialWarpPosition = _targetingIcon.localPosition + (Vector3.up * _warpTargetingInput);
		if(_potentialWarpPosition.y >= MinimumDistance && _potentialWarpPosition.y <= MaximumDistance)
		{
			_targetingIcon.localPosition = _potentialWarpPosition;
		}
	}

	#endregion
}