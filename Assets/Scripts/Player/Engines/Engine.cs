using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Engine
{
	#region Consts

	protected const float InputThreshold = 0.15f;

	#endregion

	#region Variables

	protected readonly Rigidbody2D _rigidbody;

	protected readonly float _thrustSpeed = 1f;
	protected readonly float _rotationSpeed = 0.1f;

	protected bool _thrusting;
	protected float _rotateInput;
	protected float _turnDirection = 0f;

	#endregion

	#region Lifecycle

	protected Engine(Rigidbody2D rigidbody)
	{
		_rigidbody = rigidbody;
		_rigidbody.velocity = Vector2.zero;

		HandleSubscriptions(true);
	}

	public void Deinitialize()
	{
		HandleSubscriptions(false);
	}

	public virtual void FixedUpdate()
	{
	}

	#endregion

	#region Protected Methods

	protected virtual void HandleSubscriptions(bool subscribe)
	{
	}

	protected virtual void OnMove(InputAction.CallbackContext ctx)
	{
		_thrusting = ctx.ReadValue<float>() > InputThreshold;
	}

	protected virtual void OnMoveStop(InputAction.CallbackContext ctx)
	{
		_thrusting = false;
	}

	protected virtual void OnRotate(InputAction.CallbackContext ctx)
	{
		_rotateInput = ctx.ReadValue<float>();

		if(Mathf.Abs(_rotateInput) < InputThreshold)
		{
			_turnDirection = 0;
		}

		_turnDirection = _rotateInput;
	}

	protected void StopRotate(InputAction.CallbackContext ctx)
	{
		_turnDirection = 0;
	}

	#endregion
}
