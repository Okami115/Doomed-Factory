//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Inputs/Player.inputactions
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

public partial class @Player: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""World"",
            ""id"": ""ef9a0ff5-eb2f-4250-b132-86687c3cd95f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""1fdfa198-63c7-43ba-bfd9-f4cf431d4783"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""6d775e0b-a950-439c-84f4-5fafb06fbb7b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OpenApp"",
                    ""type"": ""Button"",
                    ""id"": ""e0fd515f-7eab-499d-8ff0-29625189871d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ExitApp"",
                    ""type"": ""Button"",
                    ""id"": ""557324df-e148-4667-92d1-586d0bc92b9d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""d96f0e65-f6e3-40d7-bb68-9d86d9031335"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OpenPhone"",
                    ""type"": ""Button"",
                    ""id"": ""08c5cae5-2309-4c70-b31c-200b2a8f0063"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseScroll"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f0a5b208-2826-44b8-a898-6744bf517e26"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5995751a-280e-4561-887b-0ab4a85c128a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc3a4e84-a69e-4623-8e84-71c767e56121"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3618fd56-770c-49cf-86eb-0e479fe12521"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6aeb1212-9beb-48e3-862e-208b78b484a2"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExitApp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0ee4d0d-e587-4f7e-842e-b56282e4d069"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenPhone"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b60070de-ed13-49f4-afb3-4e51f2fa92fb"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenApp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""448a4b28-6c06-4015-be58-f3342dfb6756"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7be24a47-8bd6-4bf2-91b6-fe325134a089"",
                    ""path"": ""W"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1440fde7-43e5-4357-b4a6-e49667aa6a3a"",
                    ""path"": ""S"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""06a6aae5-e924-4b07-81e9-f45f9b1a0d0d"",
                    ""path"": ""A"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8c6de3f2-5d54-4668-9bf3-2201b1e9fa5c"",
                    ""path"": ""D"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // World
        m_World = asset.FindActionMap("World", throwIfNotFound: true);
        m_World_Move = m_World.FindAction("Move", throwIfNotFound: true);
        m_World_Interact = m_World.FindAction("Interact", throwIfNotFound: true);
        m_World_OpenApp = m_World.FindAction("OpenApp", throwIfNotFound: true);
        m_World_ExitApp = m_World.FindAction("ExitApp", throwIfNotFound: true);
        m_World_Pause = m_World.FindAction("Pause", throwIfNotFound: true);
        m_World_OpenPhone = m_World.FindAction("OpenPhone", throwIfNotFound: true);
        m_World_MouseScroll = m_World.FindAction("MouseScroll", throwIfNotFound: true);
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

    // World
    private readonly InputActionMap m_World;
    private List<IWorldActions> m_WorldActionsCallbackInterfaces = new List<IWorldActions>();
    private readonly InputAction m_World_Move;
    private readonly InputAction m_World_Interact;
    private readonly InputAction m_World_OpenApp;
    private readonly InputAction m_World_ExitApp;
    private readonly InputAction m_World_Pause;
    private readonly InputAction m_World_OpenPhone;
    private readonly InputAction m_World_MouseScroll;
    public struct WorldActions
    {
        private @Player m_Wrapper;
        public WorldActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_World_Move;
        public InputAction @Interact => m_Wrapper.m_World_Interact;
        public InputAction @OpenApp => m_Wrapper.m_World_OpenApp;
        public InputAction @ExitApp => m_Wrapper.m_World_ExitApp;
        public InputAction @Pause => m_Wrapper.m_World_Pause;
        public InputAction @OpenPhone => m_Wrapper.m_World_OpenPhone;
        public InputAction @MouseScroll => m_Wrapper.m_World_MouseScroll;
        public InputActionMap Get() { return m_Wrapper.m_World; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WorldActions set) { return set.Get(); }
        public void AddCallbacks(IWorldActions instance)
        {
            if (instance == null || m_Wrapper.m_WorldActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_WorldActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @OpenApp.started += instance.OnOpenApp;
            @OpenApp.performed += instance.OnOpenApp;
            @OpenApp.canceled += instance.OnOpenApp;
            @ExitApp.started += instance.OnExitApp;
            @ExitApp.performed += instance.OnExitApp;
            @ExitApp.canceled += instance.OnExitApp;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
            @OpenPhone.started += instance.OnOpenPhone;
            @OpenPhone.performed += instance.OnOpenPhone;
            @OpenPhone.canceled += instance.OnOpenPhone;
            @MouseScroll.started += instance.OnMouseScroll;
            @MouseScroll.performed += instance.OnMouseScroll;
            @MouseScroll.canceled += instance.OnMouseScroll;
        }

        private void UnregisterCallbacks(IWorldActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @OpenApp.started -= instance.OnOpenApp;
            @OpenApp.performed -= instance.OnOpenApp;
            @OpenApp.canceled -= instance.OnOpenApp;
            @ExitApp.started -= instance.OnExitApp;
            @ExitApp.performed -= instance.OnExitApp;
            @ExitApp.canceled -= instance.OnExitApp;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
            @OpenPhone.started -= instance.OnOpenPhone;
            @OpenPhone.performed -= instance.OnOpenPhone;
            @OpenPhone.canceled -= instance.OnOpenPhone;
            @MouseScroll.started -= instance.OnMouseScroll;
            @MouseScroll.performed -= instance.OnMouseScroll;
            @MouseScroll.canceled -= instance.OnMouseScroll;
        }

        public void RemoveCallbacks(IWorldActions instance)
        {
            if (m_Wrapper.m_WorldActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IWorldActions instance)
        {
            foreach (var item in m_Wrapper.m_WorldActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_WorldActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public WorldActions @World => new WorldActions(this);
    public interface IWorldActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnOpenApp(InputAction.CallbackContext context);
        void OnExitApp(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnOpenPhone(InputAction.CallbackContext context);
        void OnMouseScroll(InputAction.CallbackContext context);
    }
}
