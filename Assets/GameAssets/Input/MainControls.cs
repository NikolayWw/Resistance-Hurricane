//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/GameAssets/Input/MainControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @MainControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""32967f2b-bc43-45dc-a505-bcd32627626f"",
            ""actions"": [
                {
                    ""name"": ""LeftHit"",
                    ""type"": ""Button"",
                    ""id"": ""f35a248a-0557-47ef-bfad-e2dd3f8b0ee7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightHit"",
                    ""type"": ""Button"",
                    ""id"": ""a747e692-2eb4-4c91-949e-fb787feba258"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7cc476c4-6230-45f2-902b-2ff3b50d158f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftHit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be26a527-c0aa-4e02-a0dd-32983a3cea2d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftHit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d17021e-7007-455d-a24e-77face5e2b55"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightHit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d76dd696-a7ba-4b3f-aa0d-180fe21e0562"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightHit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_LeftHit = m_Player.FindAction("LeftHit", throwIfNotFound: true);
        m_Player_RightHit = m_Player.FindAction("RightHit", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_LeftHit;
    private readonly InputAction m_Player_RightHit;
    public struct PlayerActions
    {
        private @MainControls m_Wrapper;
        public PlayerActions(@MainControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftHit => m_Wrapper.m_Player_LeftHit;
        public InputAction @RightHit => m_Wrapper.m_Player_RightHit;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @LeftHit.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftHit;
                @LeftHit.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftHit;
                @LeftHit.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftHit;
                @RightHit.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightHit;
                @RightHit.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightHit;
                @RightHit.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightHit;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftHit.started += instance.OnLeftHit;
                @LeftHit.performed += instance.OnLeftHit;
                @LeftHit.canceled += instance.OnLeftHit;
                @RightHit.started += instance.OnRightHit;
                @RightHit.performed += instance.OnRightHit;
                @RightHit.canceled += instance.OnRightHit;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnLeftHit(InputAction.CallbackContext context);
        void OnRightHit(InputAction.CallbackContext context);
    }
}