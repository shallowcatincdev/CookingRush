//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/InputActions.inputactions
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

public partial class @InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""f148f756-b122-4b32-b4cb-9e1d78bef616"",
            ""actions"": [
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""193a5da4-84bd-4e68-98e3-252df8bb84bb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ClickPress"",
                    ""type"": ""Button"",
                    ""id"": ""9c762752-0f22-4e20-862f-39f8267d1a84"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ClickRelease"",
                    ""type"": ""Button"",
                    ""id"": ""9580af7b-1e94-4de8-9bbd-96cde62c52ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""614d5c28-1582-4187-b5d7-ba636217ab68"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df47ecae-08c6-46e8-944d-93896ba3565e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ClickPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bba20c6c-ade6-4108-8260-2f5c0028ede7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ClickRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_Mouse = m_Main.FindAction("Mouse", throwIfNotFound: true);
        m_Main_ClickPress = m_Main.FindAction("ClickPress", throwIfNotFound: true);
        m_Main_ClickRelease = m_Main.FindAction("ClickRelease", throwIfNotFound: true);
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

    // Main
    private readonly InputActionMap m_Main;
    private List<IMainActions> m_MainActionsCallbackInterfaces = new List<IMainActions>();
    private readonly InputAction m_Main_Mouse;
    private readonly InputAction m_Main_ClickPress;
    private readonly InputAction m_Main_ClickRelease;
    public struct MainActions
    {
        private @InputActions m_Wrapper;
        public MainActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mouse => m_Wrapper.m_Main_Mouse;
        public InputAction @ClickPress => m_Wrapper.m_Main_ClickPress;
        public InputAction @ClickRelease => m_Wrapper.m_Main_ClickRelease;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void AddCallbacks(IMainActions instance)
        {
            if (instance == null || m_Wrapper.m_MainActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MainActionsCallbackInterfaces.Add(instance);
            @Mouse.started += instance.OnMouse;
            @Mouse.performed += instance.OnMouse;
            @Mouse.canceled += instance.OnMouse;
            @ClickPress.started += instance.OnClickPress;
            @ClickPress.performed += instance.OnClickPress;
            @ClickPress.canceled += instance.OnClickPress;
            @ClickRelease.started += instance.OnClickRelease;
            @ClickRelease.performed += instance.OnClickRelease;
            @ClickRelease.canceled += instance.OnClickRelease;
        }

        private void UnregisterCallbacks(IMainActions instance)
        {
            @Mouse.started -= instance.OnMouse;
            @Mouse.performed -= instance.OnMouse;
            @Mouse.canceled -= instance.OnMouse;
            @ClickPress.started -= instance.OnClickPress;
            @ClickPress.performed -= instance.OnClickPress;
            @ClickPress.canceled -= instance.OnClickPress;
            @ClickRelease.started -= instance.OnClickRelease;
            @ClickRelease.performed -= instance.OnClickRelease;
            @ClickRelease.canceled -= instance.OnClickRelease;
        }

        public void RemoveCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMainActions instance)
        {
            foreach (var item in m_Wrapper.m_MainActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MainActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MainActions @Main => new MainActions(this);
    public interface IMainActions
    {
        void OnMouse(InputAction.CallbackContext context);
        void OnClickPress(InputAction.CallbackContext context);
        void OnClickRelease(InputAction.CallbackContext context);
    }
}
