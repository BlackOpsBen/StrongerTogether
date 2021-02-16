// GENERATED AUTOMATICALLY FROM 'Assets/Player/Player Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""DefaultActionMap"",
            ""id"": ""554dd4b1-ed11-4aa7-b67f-9ba06a2a4c28"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""8e5ce214-7733-4d84-8f21-c5f45ebce0be"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select0"",
                    ""type"": ""Button"",
                    ""id"": ""eb5ea2f8-e070-4bd5-966e-2ca635485069"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select1"",
                    ""type"": ""Button"",
                    ""id"": ""37d95e70-6c93-47e9-b1c3-5a97bfb1d288"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select2"",
                    ""type"": ""Button"",
                    ""id"": ""a79a50fc-b41f-45bb-b67e-fedc2da97929"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select3"",
                    ""type"": ""Button"",
                    ""id"": ""3075f6c0-a56d-4f9e-9efc-9d2e179618fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectNext"",
                    ""type"": ""Button"",
                    ""id"": ""7a20934e-0892-4899-84c5-c753b389f1f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectPrev"",
                    ""type"": ""Button"",
                    ""id"": ""64ad4236-0c5d-4fcf-93d5-3e6e0d542094"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""wasd"",
                    ""id"": ""dcb3217c-b1db-4c8f-bc43-cac17cea7855"",
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
                    ""id"": ""2481a5d0-445a-49fe-9649-5bd1a6ce9d3e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Kbrd"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2719a1ac-e8f3-47c5-a5b3-7d9bec37b472"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Kbrd"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4aa38c1b-1561-40a2-b8c7-7f434759526e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Kbrd"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9aa2a25d-0148-47a9-bdf1-bba2044ac362"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Kbrd"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""arrows"",
                    ""id"": ""a947ee42-2084-41d8-9f8f-532e1237b2e0"",
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
                    ""id"": ""08ea72e7-21ff-4bdf-b088-0304cf59082a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Kbrd"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""069a9e09-f66f-4d83-b8b9-843c34c88c53"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Kbrd"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""761ddd0b-7778-4dfd-9d97-9429e7918a55"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Kbrd"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e3001e64-86f7-446c-802c-d970b4381e9d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Kbrd"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0d1c5ab5-3b77-4ab0-8e61-ee4929bfd7a2"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73a333f5-2066-4c2b-a953-4747989df0cb"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0faa6ae-fbb4-4cfb-b0b2-734bdf95e3e1"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Select0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14159333-2f49-4964-9252-316ecbd8e84e"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Kbrd"",
                    ""action"": ""Select0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c727f861-21c1-41f8-811a-609be33cf246"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Select1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f3f7e73-653c-44cf-a758-a7d7fc52f1ed"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Kbrd"",
                    ""action"": ""Select1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13a56eaa-51c0-47c4-9760-93838268f6f5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Select2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2b0b807-1975-40e5-80af-3bbdff7e9b82"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Kbrd"",
                    ""action"": ""Select2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a8794b1-5c63-4178-9360-5fb486795bdf"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Select3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c3da779-1442-4ef4-a177-45acbde9d6d8"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Kbrd"",
                    ""action"": ""Select3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""827659e2-c979-4446-a4e8-0a17d4871589"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""SelectNext"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b4ce24b-7f7d-497c-a400-5b0b8e396cde"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Kbrd"",
                    ""action"": ""SelectNext"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5acef486-ed03-4f40-9e82-71e2b3aed95d"",
                    ""path"": ""<Keyboard>/period"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Kbrd"",
                    ""action"": ""SelectNext"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed7fac95-0b00-493a-9b37-fa157e556bb2"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""SelectPrev"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05f6bb55-7af9-43b0-b9ee-9d756227ab58"",
                    ""path"": ""<Keyboard>/comma"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Kbrd"",
                    ""action"": ""SelectPrev"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Kbrd"",
            ""bindingGroup"": ""Kbrd"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
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
        }
    ]
}");
        // DefaultActionMap
        m_DefaultActionMap = asset.FindActionMap("DefaultActionMap", throwIfNotFound: true);
        m_DefaultActionMap_Move = m_DefaultActionMap.FindAction("Move", throwIfNotFound: true);
        m_DefaultActionMap_Select0 = m_DefaultActionMap.FindAction("Select0", throwIfNotFound: true);
        m_DefaultActionMap_Select1 = m_DefaultActionMap.FindAction("Select1", throwIfNotFound: true);
        m_DefaultActionMap_Select2 = m_DefaultActionMap.FindAction("Select2", throwIfNotFound: true);
        m_DefaultActionMap_Select3 = m_DefaultActionMap.FindAction("Select3", throwIfNotFound: true);
        m_DefaultActionMap_SelectNext = m_DefaultActionMap.FindAction("SelectNext", throwIfNotFound: true);
        m_DefaultActionMap_SelectPrev = m_DefaultActionMap.FindAction("SelectPrev", throwIfNotFound: true);
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

    // DefaultActionMap
    private readonly InputActionMap m_DefaultActionMap;
    private IDefaultActionMapActions m_DefaultActionMapActionsCallbackInterface;
    private readonly InputAction m_DefaultActionMap_Move;
    private readonly InputAction m_DefaultActionMap_Select0;
    private readonly InputAction m_DefaultActionMap_Select1;
    private readonly InputAction m_DefaultActionMap_Select2;
    private readonly InputAction m_DefaultActionMap_Select3;
    private readonly InputAction m_DefaultActionMap_SelectNext;
    private readonly InputAction m_DefaultActionMap_SelectPrev;
    public struct DefaultActionMapActions
    {
        private @PlayerControls m_Wrapper;
        public DefaultActionMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_DefaultActionMap_Move;
        public InputAction @Select0 => m_Wrapper.m_DefaultActionMap_Select0;
        public InputAction @Select1 => m_Wrapper.m_DefaultActionMap_Select1;
        public InputAction @Select2 => m_Wrapper.m_DefaultActionMap_Select2;
        public InputAction @Select3 => m_Wrapper.m_DefaultActionMap_Select3;
        public InputAction @SelectNext => m_Wrapper.m_DefaultActionMap_SelectNext;
        public InputAction @SelectPrev => m_Wrapper.m_DefaultActionMap_SelectPrev;
        public InputActionMap Get() { return m_Wrapper.m_DefaultActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActionMapActions instance)
        {
            if (m_Wrapper.m_DefaultActionMapActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnMove;
                @Select0.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSelect0;
                @Select0.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSelect0;
                @Select0.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSelect0;
                @Select1.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSelect1;
                @Select1.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSelect1;
                @Select1.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSelect1;
                @Select2.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSelect2;
                @Select2.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSelect2;
                @Select2.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSelect2;
                @Select3.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSelect3;
                @Select3.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSelect3;
                @Select3.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSelect3;
                @SelectNext.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSelectNext;
                @SelectNext.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSelectNext;
                @SelectNext.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSelectNext;
                @SelectPrev.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSelectPrev;
                @SelectPrev.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSelectPrev;
                @SelectPrev.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSelectPrev;
            }
            m_Wrapper.m_DefaultActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Select0.started += instance.OnSelect0;
                @Select0.performed += instance.OnSelect0;
                @Select0.canceled += instance.OnSelect0;
                @Select1.started += instance.OnSelect1;
                @Select1.performed += instance.OnSelect1;
                @Select1.canceled += instance.OnSelect1;
                @Select2.started += instance.OnSelect2;
                @Select2.performed += instance.OnSelect2;
                @Select2.canceled += instance.OnSelect2;
                @Select3.started += instance.OnSelect3;
                @Select3.performed += instance.OnSelect3;
                @Select3.canceled += instance.OnSelect3;
                @SelectNext.started += instance.OnSelectNext;
                @SelectNext.performed += instance.OnSelectNext;
                @SelectNext.canceled += instance.OnSelectNext;
                @SelectPrev.started += instance.OnSelectPrev;
                @SelectPrev.performed += instance.OnSelectPrev;
                @SelectPrev.canceled += instance.OnSelectPrev;
            }
        }
    }
    public DefaultActionMapActions @DefaultActionMap => new DefaultActionMapActions(this);
    private int m_KbrdSchemeIndex = -1;
    public InputControlScheme KbrdScheme
    {
        get
        {
            if (m_KbrdSchemeIndex == -1) m_KbrdSchemeIndex = asset.FindControlSchemeIndex("Kbrd");
            return asset.controlSchemes[m_KbrdSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IDefaultActionMapActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSelect0(InputAction.CallbackContext context);
        void OnSelect1(InputAction.CallbackContext context);
        void OnSelect2(InputAction.CallbackContext context);
        void OnSelect3(InputAction.CallbackContext context);
        void OnSelectNext(InputAction.CallbackContext context);
        void OnSelectPrev(InputAction.CallbackContext context);
    }
}
