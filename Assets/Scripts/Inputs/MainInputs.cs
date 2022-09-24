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
            ""name"": ""StandardEngine"",
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
                    ""path"": ""<Gamepad>/rightStick/x"",
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
                    ""name"": ""ArrowKeys"",
                    ""id"": ""eeba79e0-3b14-4eed-a9e0-f99bf5bcc55c"",
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
                    ""id"": ""b90d06fb-c5b6-474b-a3e6-1e8a93d76559"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""184279bc-055c-4884-bbbd-1a0fff5a8f38"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
                    ""id"": ""5772c649-e12c-4fb1-98b0-31f8b60930c8"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""DecoupledEngine"",
            ""id"": ""bd715c00-89ee-4529-9a94-842efcd48b95"",
            ""actions"": [
                {
                    ""name"": ""Locomotion"",
                    ""type"": ""Value"",
                    ""id"": ""2768cbd7-c774-4e8b-9184-e9ef11118493"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""330e7cc7-7fc2-4b25-a0bd-26750832afcd"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": ""Invert"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""32e83e88-b137-40cf-b995-b0c9fb5414d2"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Locomotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ab54fa2e-1631-4f4a-86a4-cdf8cadd12ab"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Locomotion"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a3590324-c1ee-4864-8e3f-7e5e458395c1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Locomotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""047d47fc-adc6-43ad-91a5-565f2d005a89"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Locomotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bec3a303-f9cf-4afb-8f76-fe50e3dda2aa"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Locomotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e3808e72-ce3f-4f12-bf96-bd7757be2387"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Locomotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c7db0ed5-3974-4555-93fd-cc2ab51e159b"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""3e75b1d9-9828-47ca-9f23-dd909267129a"",
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
                    ""id"": ""bbf01850-3635-44c9-af4c-b5e87cd58c48"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e6ae31c2-8602-4470-88d4-a91a6ada9e57"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""757bf0ff-9788-45f7-a426-00a3a0a08872"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""WeaponsSystem"",
            ""id"": ""c9e13d37-7788-4d14-953f-5b2b35fccc1c"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""50e75412-504d-4e1e-8c02-b51dce9e0de0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""27db5aff-04d9-4e5d-a18a-e644aa735277"",
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
                    ""id"": ""d6fb9748-7e82-4c43-bc83-d8e1b446b591"",
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
                    ""id"": ""1b22b021-3b13-48f7-b867-a71ce73b769c"",
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
                    ""id"": ""76a2acf7-0b59-4e8a-95ec-3a7f79297f01"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""097f242c-ae67-47d2-bd0b-4bcf6e4833e5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""WarpJump"",
            ""id"": ""08130992-70a8-4f2b-ac10-4d58c8a2570a"",
            ""actions"": [
                {
                    ""name"": ""Warp"",
                    ""type"": ""Button"",
                    ""id"": ""9be550d6-3c33-4beb-82e8-628dc68be465"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WarpTargeting"",
                    ""type"": ""Value"",
                    ""id"": ""095313c2-0edd-4a27-994f-61c2ba9084a3"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2b033a73-987f-4f1b-b8e5-17ecd47c0332"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Warp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23c86ca5-c421-4bae-b692-4d81f500717b"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Warp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""902ed724-2ee4-4f5b-8acd-5a69f15d5447"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Warp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95dbd83d-a401-403d-b2b4-5d04c49cadcc"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Warp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24ddd17b-da59-4ea3-a995-cd238a2ca20d"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""WarpTargeting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c900ff9e-4fd1-48d3-b045-6636a395e4ea"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""WarpTargeting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""64198da7-cafa-4bb4-8f9a-4e12f76167d3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WarpTargeting"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7eadc8d3-41fd-44a8-8ee9-21350b51d764"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""WarpTargeting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""453e9746-b5b6-4666-a2a6-c85af22fd3ea"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""WarpTargeting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
        // StandardEngine
        m_StandardEngine = asset.FindActionMap("StandardEngine", throwIfNotFound: true);
        m_StandardEngine_Forward = m_StandardEngine.FindAction("Forward", throwIfNotFound: true);
        m_StandardEngine_Rotate = m_StandardEngine.FindAction("Rotate", throwIfNotFound: true);
        // DecoupledEngine
        m_DecoupledEngine = asset.FindActionMap("DecoupledEngine", throwIfNotFound: true);
        m_DecoupledEngine_Locomotion = m_DecoupledEngine.FindAction("Locomotion", throwIfNotFound: true);
        m_DecoupledEngine_Rotate = m_DecoupledEngine.FindAction("Rotate", throwIfNotFound: true);
        // WeaponsSystem
        m_WeaponsSystem = asset.FindActionMap("WeaponsSystem", throwIfNotFound: true);
        m_WeaponsSystem_Fire = m_WeaponsSystem.FindAction("Fire", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Enter = m_Menu.FindAction("Enter", throwIfNotFound: true);
        // WarpJump
        m_WarpJump = asset.FindActionMap("WarpJump", throwIfNotFound: true);
        m_WarpJump_Warp = m_WarpJump.FindAction("Warp", throwIfNotFound: true);
        m_WarpJump_WarpTargeting = m_WarpJump.FindAction("WarpTargeting", throwIfNotFound: true);
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

    // StandardEngine
    private readonly InputActionMap m_StandardEngine;
    private IStandardEngineActions m_StandardEngineActionsCallbackInterface;
    private readonly InputAction m_StandardEngine_Forward;
    private readonly InputAction m_StandardEngine_Rotate;
    public struct StandardEngineActions
    {
        private @MainInputs m_Wrapper;
        public StandardEngineActions(@MainInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_StandardEngine_Forward;
        public InputAction @Rotate => m_Wrapper.m_StandardEngine_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_StandardEngine; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StandardEngineActions set) { return set.Get(); }
        public void SetCallbacks(IStandardEngineActions instance)
        {
            if (m_Wrapper.m_StandardEngineActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_StandardEngineActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_StandardEngineActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_StandardEngineActionsCallbackInterface.OnForward;
                @Rotate.started -= m_Wrapper.m_StandardEngineActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_StandardEngineActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_StandardEngineActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_StandardEngineActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public StandardEngineActions @StandardEngine => new StandardEngineActions(this);

    // DecoupledEngine
    private readonly InputActionMap m_DecoupledEngine;
    private IDecoupledEngineActions m_DecoupledEngineActionsCallbackInterface;
    private readonly InputAction m_DecoupledEngine_Locomotion;
    private readonly InputAction m_DecoupledEngine_Rotate;
    public struct DecoupledEngineActions
    {
        private @MainInputs m_Wrapper;
        public DecoupledEngineActions(@MainInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Locomotion => m_Wrapper.m_DecoupledEngine_Locomotion;
        public InputAction @Rotate => m_Wrapper.m_DecoupledEngine_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_DecoupledEngine; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DecoupledEngineActions set) { return set.Get(); }
        public void SetCallbacks(IDecoupledEngineActions instance)
        {
            if (m_Wrapper.m_DecoupledEngineActionsCallbackInterface != null)
            {
                @Locomotion.started -= m_Wrapper.m_DecoupledEngineActionsCallbackInterface.OnLocomotion;
                @Locomotion.performed -= m_Wrapper.m_DecoupledEngineActionsCallbackInterface.OnLocomotion;
                @Locomotion.canceled -= m_Wrapper.m_DecoupledEngineActionsCallbackInterface.OnLocomotion;
                @Rotate.started -= m_Wrapper.m_DecoupledEngineActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_DecoupledEngineActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_DecoupledEngineActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_DecoupledEngineActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Locomotion.started += instance.OnLocomotion;
                @Locomotion.performed += instance.OnLocomotion;
                @Locomotion.canceled += instance.OnLocomotion;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public DecoupledEngineActions @DecoupledEngine => new DecoupledEngineActions(this);

    // WeaponsSystem
    private readonly InputActionMap m_WeaponsSystem;
    private IWeaponsSystemActions m_WeaponsSystemActionsCallbackInterface;
    private readonly InputAction m_WeaponsSystem_Fire;
    public struct WeaponsSystemActions
    {
        private @MainInputs m_Wrapper;
        public WeaponsSystemActions(@MainInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_WeaponsSystem_Fire;
        public InputActionMap Get() { return m_Wrapper.m_WeaponsSystem; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WeaponsSystemActions set) { return set.Get(); }
        public void SetCallbacks(IWeaponsSystemActions instance)
        {
            if (m_Wrapper.m_WeaponsSystemActionsCallbackInterface != null)
            {
                @Fire.started -= m_Wrapper.m_WeaponsSystemActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_WeaponsSystemActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_WeaponsSystemActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_WeaponsSystemActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public WeaponsSystemActions @WeaponsSystem => new WeaponsSystemActions(this);

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

    // WarpJump
    private readonly InputActionMap m_WarpJump;
    private IWarpJumpActions m_WarpJumpActionsCallbackInterface;
    private readonly InputAction m_WarpJump_Warp;
    private readonly InputAction m_WarpJump_WarpTargeting;
    public struct WarpJumpActions
    {
        private @MainInputs m_Wrapper;
        public WarpJumpActions(@MainInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Warp => m_Wrapper.m_WarpJump_Warp;
        public InputAction @WarpTargeting => m_Wrapper.m_WarpJump_WarpTargeting;
        public InputActionMap Get() { return m_Wrapper.m_WarpJump; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WarpJumpActions set) { return set.Get(); }
        public void SetCallbacks(IWarpJumpActions instance)
        {
            if (m_Wrapper.m_WarpJumpActionsCallbackInterface != null)
            {
                @Warp.started -= m_Wrapper.m_WarpJumpActionsCallbackInterface.OnWarp;
                @Warp.performed -= m_Wrapper.m_WarpJumpActionsCallbackInterface.OnWarp;
                @Warp.canceled -= m_Wrapper.m_WarpJumpActionsCallbackInterface.OnWarp;
                @WarpTargeting.started -= m_Wrapper.m_WarpJumpActionsCallbackInterface.OnWarpTargeting;
                @WarpTargeting.performed -= m_Wrapper.m_WarpJumpActionsCallbackInterface.OnWarpTargeting;
                @WarpTargeting.canceled -= m_Wrapper.m_WarpJumpActionsCallbackInterface.OnWarpTargeting;
            }
            m_Wrapper.m_WarpJumpActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Warp.started += instance.OnWarp;
                @Warp.performed += instance.OnWarp;
                @Warp.canceled += instance.OnWarp;
                @WarpTargeting.started += instance.OnWarpTargeting;
                @WarpTargeting.performed += instance.OnWarpTargeting;
                @WarpTargeting.canceled += instance.OnWarpTargeting;
            }
        }
    }
    public WarpJumpActions @WarpJump => new WarpJumpActions(this);
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
    public interface IStandardEngineActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
    public interface IDecoupledEngineActions
    {
        void OnLocomotion(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
    public interface IWeaponsSystemActions
    {
        void OnFire(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnEnter(InputAction.CallbackContext context);
    }
    public interface IWarpJumpActions
    {
        void OnWarp(InputAction.CallbackContext context);
        void OnWarpTargeting(InputAction.CallbackContext context);
    }
}
