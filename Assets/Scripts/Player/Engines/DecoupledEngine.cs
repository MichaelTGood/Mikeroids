using UnityEngine;
using UnityEngine.InputSystem;

public class DecoupledEngine : Engine
{
	#region Variables

	private Vector2 _movementDirection;

	#endregion

	public DecoupledEngine(Rigidbody2D rigidbody) 
		: base(rigidbody)
	{
	}

	#region Lifecycle

	public override void FixedUpdate()
	{
		if((Mathf.Abs(_movementDirection.x) > InputThreshold || Mathf.Abs(_movementDirection.y) > InputThreshold))
		{
			_rigidbody.AddForce(_movementDirection * _thrustSpeed);
		}

		if(_turnDirection != 0f)
		{
			_rigidbody.AddTorque(_rotationSpeed * _turnDirection);
		}
	}

	#endregion
	
	#region Private Methods

	protected override void HandleSubscriptions(bool subscribe)
	{
		if(subscribe)
		{
			InputManager.DecoupledEngine.Enable();
			InputManager.DecoupledEngine.Locomotion.performed += OnMove;
			InputManager.DecoupledEngine.Locomotion.canceled += OnMoveStop;
			InputManager.DecoupledEngine.Rotate.performed += OnRotate;
			InputManager.DecoupledEngine.Rotate.canceled += StopRotate;
		}
		else
		{
			InputManager.DecoupledEngine.Disable();
			InputManager.DecoupledEngine.Locomotion.performed -= OnMove;
			InputManager.DecoupledEngine.Locomotion.canceled -= OnMoveStop;
			InputManager.DecoupledEngine.Rotate.performed -= OnRotate;
			InputManager.DecoupledEngine.Rotate.canceled -= StopRotate;
		}
	}

	protected override void OnMove(InputAction.CallbackContext ctx)
	{
		_movementDirection = ctx.ReadValue<Vector2>().normalized;
	}

	protected override void OnMoveStop(InputAction.CallbackContext ctx)
	{
		_movementDirection = Vector2.zero;
	}

	#endregion
}
