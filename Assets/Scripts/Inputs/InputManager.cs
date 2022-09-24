using UnityEngine.InputSystem;

public class InputManager
	{
		#region Variables

		private static MainInputs Input = new MainInputs();

		#endregion

		#region Properties

		public static MainInputs.StandardEngineActions StandardEngine => Input.StandardEngine;

		public static MainInputs.DecoupledEngineActions DecoupledEngine => Input.DecoupledEngine;

		public static MainInputs.WeaponsSystemActions WeaponsSystem => Input.WeaponsSystem;

		public static MainInputs.WarpJumpActions WarpJump => Input.WarpJump;

		public static MainInputs.MenuActions Menu => Input.Menu;

		#endregion
		
		public static void SwitchToActionMap(InputActionMap actionMap)
		{
			if(actionMap.enabled) return;

			Input.Disable();
			actionMap.Enable();
		}
		
		public static void SwitchToMenuInputMap()
		{
			Input.Disable();
			Menu.Enable();
		}
	}