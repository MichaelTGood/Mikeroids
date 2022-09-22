// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/MainInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainInputs"",
    ""maps"": [
        {
            ""name"": ""Ship Standard"",
            ""id"": ""e526106a-14fd-41ae-b24a-c65d12d768e0"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""4246f738-620f-4c09-8fca-8fd8dd8efc7b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""06fff705-0f40-4d1c-90a5-07f9e71e9e15"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": ""Invert"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""a8fe957b-c301-4346-8596-90922a4bd6df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d040f358-48f9-496e-8f41-a9df26a0dbef"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""24de651a-9ac3-4d86-a704-c1d95cc6105c"",
                    ""path"": ""1DAxis(minValue=0,whichSideWins=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""dc3088a7-f5a5-447d-b2a2-1b0bf2a6101e"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7612e894-0e19-4de5-91cf-a7b5538986c6"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1a4770b4-cceb-458e-b714-a3327d441e9a"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""938fc182-e13b-41d0-b3d7-cf449a860d2b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""26d2b3d9-b014-4a1a-afc6-0c4acbd2a6d1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4c943e9a-f088-4ce7-afa0-95e617b2a30c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""89bba2c0-e20e-46c3-9559-a7642d2c4f86"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a081425b-8bdb-4ffd-b360-b4207140609b"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffa37143-3ee7-4a27-a28a-38a26e629931"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1c01c2f-f32a-4870-9185-b40d6b8edb4a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""8e63192e-5ced-4472-89ea-d5f876a56b3d"",
            ""actions"": [
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""5f79d011-f9f6-46f1-abf8-de6284c2e38e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3b3595b3-446c-47d2-b4a3-8ee89c0a8e8d"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35cb1faf-0634-47b5-9d02-1c85ab667960"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a226423-d4e7-4d1c-9e80-84651007e2d1"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05527e75-1e9d-42ba-ad87-79aaaf101bbd"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Ship Standard
        m_ShipStandard = asset.FindActionMap("Ship Standard", throwIfNotFound: true);
        m_ShipStandard_Forward = m_ShipStandard.FindAction("Forward", throwIfNotFound: true);
        m_ShipStandard_Rotate = m_ShipStandard.FindAction("Rotate", throwIfNotFound: true);
        m_ShipStandard_Fire = m_ShipStandard.FindAction("Fire", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Enter = m_Menu.FindAction("Enter", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Ship Standard
    private readonly InputActionMap m_ShipStandard;
    private IShipStandardActions m_ShipStandardActionsCallbackInterface;
    private readonly InputAction m_ShipStandard_Forward;
    private readonly InputAction m_ShipStandard_Rotate;
    private readonly InputAction m_ShipStandard_Fire;
    public struct ShipStandardActions
    {
        private @MainInputs m_Wrapper;
        public ShipStandardActions(@MainInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_ShipStandard_Forward;
        public InputAction @Rotate => m_Wrapper.m_ShipStandard_Rotate;
        public InputAction @Fire => m_Wrapper.m_ShipStandard_Fire;
        public InputActionMap Get() { return m_Wrapper.m_ShipStandard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShipStandardActions set) { return set.Get(); }
        public void SetCallbacks(IShipStandardActions instance)
        {
            if (m_Wrapper.m_ShipStandardActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_ShipStandardActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_ShipStandardActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_ShipStandardActionsCallbackInterface.OnForward;
                @Rotate.started -= m_Wrapper.m_ShipStandardActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_ShipStandardActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_ShipStandardActionsCallbackInterface.OnRotate;
                @Fire.started -= m_Wrapper.m_ShipStandardActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_ShipStandardActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_ShipStandardActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_ShipStandardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public ShipStandardActions @ShipStandard => new ShipStandardActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Enter;
    public struct MenuActions
    {
        private @MainInputs m_Wrapper;
        public MenuActions(@MainInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Enter => m_Wrapper.m_Menu_Enter;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Enter.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnEnter;
                @Enter.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnEnter;
                @Enter.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnEnter;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Enter.started += instance.OnEnter;
                @Enter.performed += instance.OnEnter;
                @Enter.canceled += instance.OnEnter;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    public interface IShipStandardActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnEnter(InputAction.CallbackContext context);
    }
}
