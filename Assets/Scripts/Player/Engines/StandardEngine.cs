using UnityEngine;

public class StandardEngine : Engine
{
	#region Variables

	private readonly Transform _shipTransform;

	#endregion

	#region Lifecycle

	public StandardEngine(Transform shipTransform, Rigidbody2D rigidbody)
		: base(rigidbody)
	{
		_shipTransform = shipTransform;
	}

	public override void FixedUpdate()
	{
		if(_thrusting)
		{
			_rigidbody.AddForce(_shipTransform.up * _thrustSpeed);
		}

		if(_turnDirection != 0f)
		{
			_rigidbody.AddTorque(_rotationSpeed * _turnDirection);
		}
	}

	#endregion

	#region Protected Methods

	protected override void HandleSubscriptions(bool subscribe)
	{
		if(subscribe)
		{
			InputManager.StandardEngine.Enable();
			InputManager.StandardEngine.Forward.performed += OnMove;
			InputManager.StandardEngine.Forward.canceled += OnMoveStop;
			InputManager.StandardEngine.Rotate.performed += OnRotate;
			InputManager.StandardEngine.Rotate.canceled += StopRotate;
		}
		else
		{
			InputManager.StandardEngine.Disable();
			InputManager.StandardEngine.Forward.performed -= OnMove;
			InputManager.StandardEngine.Forward.canceled -= OnMoveStop;
			InputManager.StandardEngine.Rotate.performed -= OnRotate;
			InputManager.StandardEngine.Rotate.canceled -= StopRotate;
		}
	}

	#endregion
}
