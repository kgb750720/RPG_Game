// GENERATED AUTOMATICALLY FROM 'Assets/Input/Control.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Control : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Control()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Control"",
    ""maps"": [
        {
            ""name"": ""MyControls"",
            ""id"": ""1e8648e4-3baa-4b97-8254-28562062945f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""551bea0a-1c43-4c33-843f-f245fd8810eb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveBack"",
                    ""type"": ""Button"",
                    ""id"": ""9a50530b-7b1d-4c63-bf5f-cbe7bc24d4d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""9043ae81-ac8f-4dbb-8209-2b06be3c64ba"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HoldRotate"",
                    ""type"": ""Button"",
                    ""id"": ""e0ecc9e1-78ab-45e7-880b-c557ee19eb93"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fast"",
                    ""type"": ""Button"",
                    ""id"": ""6eaed092-a3ca-4538-b8f0-62db31f6476d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GetTool"",
                    ""type"": ""Button"",
                    ""id"": ""c8fe77e6-2c04-4724-8bc6-d134fb374254"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ae7372ae-c2fa-4dac-89ba-108c618ef869"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""584703cc-a77c-4d5c-8537-18f8c00a0542"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa3425bc-56b7-46c1-b091-a06d20d1b098"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HoldRotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9edf50ea-ddce-4a25-bcad-4d5b0e42736f"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71142f0b-e0e1-4a0d-adf2-f7c74d2f8fb2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GetTool"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bba93ea-2144-48f9-b3da-585fa2c5a0f6"",
                    ""path"": ""<Keyboard>/#(W)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f888ce0-9734-48c9-a206-dc2227476e0b"",
                    ""path"": ""<Keyboard>/#(S)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d532282-a684-40fe-8f0e-dfbb7ec38901"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MyAtt"",
            ""id"": ""3da3fb0c-350b-4776-bcb8-b5aabf475927"",
            ""actions"": [
                {
                    ""name"": ""SwordOut"",
                    ""type"": ""Button"",
                    ""id"": ""ede67393-96f2-44fe-a8a0-a4a2036d3cc7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Att"",
                    ""type"": ""Button"",
                    ""id"": ""2dab680a-1584-4238-b4bc-85f2d8280ddb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9c8db341-b441-4d35-b032-9a1ca76c7873"",
                    ""path"": ""<Keyboard>/#(E)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwordOut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f8217c6-0f72-40ad-b4db-1fb06d352a19"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Att"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Hmp"",
            ""id"": ""15664f6f-5f26-415e-9730-2dde2c09df2a"",
            ""actions"": [
                {
                    ""name"": ""1"",
                    ""type"": ""Button"",
                    ""id"": ""391816b2-3d4c-47d5-9be2-9e07f00580a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""2"",
                    ""type"": ""Button"",
                    ""id"": ""48e313c6-de9a-4d99-a078-611de6c804d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""3"",
                    ""type"": ""Button"",
                    ""id"": ""249464d7-8800-437c-9828-99d2ed162250"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""4"",
                    ""type"": ""Button"",
                    ""id"": ""1bc8367c-ba38-48b4-b764-046c5a5cddde"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""5"",
                    ""type"": ""Button"",
                    ""id"": ""f735414b-2bd9-4aa4-9f1b-16355de239af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""6"",
                    ""type"": ""Button"",
                    ""id"": ""bb4cef71-7532-469a-870e-2bde259e95c2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""7"",
                    ""type"": ""Button"",
                    ""id"": ""1ea4b495-589b-4115-a471-c263d833f6cf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""8"",
                    ""type"": ""Button"",
                    ""id"": ""765e3935-98c5-4278-9058-cfe671b14802"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6bc848cf-8da2-464c-810c-278c7c0150b3"",
                    ""path"": ""<Keyboard>/#(1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b7dd713-2f5a-44e7-a35e-e3642d42be81"",
                    ""path"": ""<Keyboard>/#(2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a313f1c4-bfce-40ae-9fd6-0ee960398ee4"",
                    ""path"": ""<Keyboard>/#(3)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bead2d13-cfc4-46bb-8d4d-b01bbf81e43c"",
                    ""path"": ""<Keyboard>/#(4)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89ebfb74-8e36-42cb-a8ee-abd3c161a3a1"",
                    ""path"": ""<Keyboard>/#(5)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fafb60d2-0314-4f7f-8fbc-3e52b575a858"",
                    ""path"": ""<Keyboard>/#(6)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""126e5d7e-4312-434f-ab47-f08b4b05b390"",
                    ""path"": ""<Keyboard>/#(7)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""7"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdb7313c-c2ed-4374-924a-d084ca91500c"",
                    ""path"": ""<Keyboard>/#(8)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""8"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Skill"",
            ""id"": ""06c11dd5-7d8d-4d6c-8cde-5070340f1c61"",
            ""actions"": [
                {
                    ""name"": ""F1"",
                    ""type"": ""Button"",
                    ""id"": ""c6996f0b-3166-427b-a452-2dbf0b915d7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F2"",
                    ""type"": ""Button"",
                    ""id"": ""0224d182-9ae5-4514-8d4f-4819ad7232f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F3"",
                    ""type"": ""Button"",
                    ""id"": ""95bab2f5-58cb-4bc8-805a-89b56e73ca6e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F4"",
                    ""type"": ""Button"",
                    ""id"": ""31184c0e-f506-4a24-abf1-7a33a9400d3d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F5"",
                    ""type"": ""Button"",
                    ""id"": ""d2fb46c5-b109-49e0-90cf-1b181cf70f0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F6"",
                    ""type"": ""Button"",
                    ""id"": ""dd84fcc4-7f8f-4521-bf2a-89901ef6fb75"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b708726d-b88b-4a89-b11b-947bcec866b2"",
                    ""path"": ""<Keyboard>/f1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2db8acc7-62da-4562-96ab-6a2d98370d5b"",
                    ""path"": ""<Keyboard>/f2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9214477c-c6c6-4dfc-bdc5-d4f96f709b37"",
                    ""path"": ""<Keyboard>/f3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75e93d17-fdd1-46b1-92d3-97948d6d30f9"",
                    ""path"": ""<Keyboard>/f4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f33c731-35e5-4460-af9a-144803e1ae11"",
                    ""path"": ""<Keyboard>/f5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""169ea6bd-9c96-45c1-8b7c-289a28457ae3"",
                    ""path"": ""<Keyboard>/f6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MyControls
        m_MyControls = asset.FindActionMap("MyControls", throwIfNotFound: true);
        m_MyControls_Move = m_MyControls.FindAction("Move", throwIfNotFound: true);
        m_MyControls_MoveBack = m_MyControls.FindAction("MoveBack", throwIfNotFound: true);
        m_MyControls_Rotate = m_MyControls.FindAction("Rotate", throwIfNotFound: true);
        m_MyControls_HoldRotate = m_MyControls.FindAction("HoldRotate", throwIfNotFound: true);
        m_MyControls_Fast = m_MyControls.FindAction("Fast", throwIfNotFound: true);
        m_MyControls_GetTool = m_MyControls.FindAction("GetTool", throwIfNotFound: true);
        m_MyControls_Jump = m_MyControls.FindAction("Jump", throwIfNotFound: true);
        // MyAtt
        m_MyAtt = asset.FindActionMap("MyAtt", throwIfNotFound: true);
        m_MyAtt_SwordOut = m_MyAtt.FindAction("SwordOut", throwIfNotFound: true);
        m_MyAtt_Att = m_MyAtt.FindAction("Att", throwIfNotFound: true);
        // Hmp
        m_Hmp = asset.FindActionMap("Hmp", throwIfNotFound: true);
        m_Hmp__1 = m_Hmp.FindAction("1", throwIfNotFound: true);
        m_Hmp__2 = m_Hmp.FindAction("2", throwIfNotFound: true);
        m_Hmp__3 = m_Hmp.FindAction("3", throwIfNotFound: true);
        m_Hmp__4 = m_Hmp.FindAction("4", throwIfNotFound: true);
        m_Hmp__5 = m_Hmp.FindAction("5", throwIfNotFound: true);
        m_Hmp__6 = m_Hmp.FindAction("6", throwIfNotFound: true);
        m_Hmp__7 = m_Hmp.FindAction("7", throwIfNotFound: true);
        m_Hmp__8 = m_Hmp.FindAction("8", throwIfNotFound: true);
        // Skill
        m_Skill = asset.FindActionMap("Skill", throwIfNotFound: true);
        m_Skill_F1 = m_Skill.FindAction("F1", throwIfNotFound: true);
        m_Skill_F2 = m_Skill.FindAction("F2", throwIfNotFound: true);
        m_Skill_F3 = m_Skill.FindAction("F3", throwIfNotFound: true);
        m_Skill_F4 = m_Skill.FindAction("F4", throwIfNotFound: true);
        m_Skill_F5 = m_Skill.FindAction("F5", throwIfNotFound: true);
        m_Skill_F6 = m_Skill.FindAction("F6", throwIfNotFound: true);
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

    // MyControls
    private readonly InputActionMap m_MyControls;
    private IMyControlsActions m_MyControlsActionsCallbackInterface;
    private readonly InputAction m_MyControls_Move;
    private readonly InputAction m_MyControls_MoveBack;
    private readonly InputAction m_MyControls_Rotate;
    private readonly InputAction m_MyControls_HoldRotate;
    private readonly InputAction m_MyControls_Fast;
    private readonly InputAction m_MyControls_GetTool;
    private readonly InputAction m_MyControls_Jump;
    public struct MyControlsActions
    {
        private @Control m_Wrapper;
        public MyControlsActions(@Control wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_MyControls_Move;
        public InputAction @MoveBack => m_Wrapper.m_MyControls_MoveBack;
        public InputAction @Rotate => m_Wrapper.m_MyControls_Rotate;
        public InputAction @HoldRotate => m_Wrapper.m_MyControls_HoldRotate;
        public InputAction @Fast => m_Wrapper.m_MyControls_Fast;
        public InputAction @GetTool => m_Wrapper.m_MyControls_GetTool;
        public InputAction @Jump => m_Wrapper.m_MyControls_Jump;
        public InputActionMap Get() { return m_Wrapper.m_MyControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MyControlsActions set) { return set.Get(); }
        public void SetCallbacks(IMyControlsActions instance)
        {
            if (m_Wrapper.m_MyControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnMove;
                @MoveBack.started -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnMoveBack;
                @MoveBack.performed -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnMoveBack;
                @MoveBack.canceled -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnMoveBack;
                @Rotate.started -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnRotate;
                @HoldRotate.started -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnHoldRotate;
                @HoldRotate.performed -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnHoldRotate;
                @HoldRotate.canceled -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnHoldRotate;
                @Fast.started -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnFast;
                @Fast.performed -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnFast;
                @Fast.canceled -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnFast;
                @GetTool.started -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnGetTool;
                @GetTool.performed -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnGetTool;
                @GetTool.canceled -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnGetTool;
                @Jump.started -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MyControlsActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_MyControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @MoveBack.started += instance.OnMoveBack;
                @MoveBack.performed += instance.OnMoveBack;
                @MoveBack.canceled += instance.OnMoveBack;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @HoldRotate.started += instance.OnHoldRotate;
                @HoldRotate.performed += instance.OnHoldRotate;
                @HoldRotate.canceled += instance.OnHoldRotate;
                @Fast.started += instance.OnFast;
                @Fast.performed += instance.OnFast;
                @Fast.canceled += instance.OnFast;
                @GetTool.started += instance.OnGetTool;
                @GetTool.performed += instance.OnGetTool;
                @GetTool.canceled += instance.OnGetTool;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public MyControlsActions @MyControls => new MyControlsActions(this);

    // MyAtt
    private readonly InputActionMap m_MyAtt;
    private IMyAttActions m_MyAttActionsCallbackInterface;
    private readonly InputAction m_MyAtt_SwordOut;
    private readonly InputAction m_MyAtt_Att;
    public struct MyAttActions
    {
        private @Control m_Wrapper;
        public MyAttActions(@Control wrapper) { m_Wrapper = wrapper; }
        public InputAction @SwordOut => m_Wrapper.m_MyAtt_SwordOut;
        public InputAction @Att => m_Wrapper.m_MyAtt_Att;
        public InputActionMap Get() { return m_Wrapper.m_MyAtt; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MyAttActions set) { return set.Get(); }
        public void SetCallbacks(IMyAttActions instance)
        {
            if (m_Wrapper.m_MyAttActionsCallbackInterface != null)
            {
                @SwordOut.started -= m_Wrapper.m_MyAttActionsCallbackInterface.OnSwordOut;
                @SwordOut.performed -= m_Wrapper.m_MyAttActionsCallbackInterface.OnSwordOut;
                @SwordOut.canceled -= m_Wrapper.m_MyAttActionsCallbackInterface.OnSwordOut;
                @Att.started -= m_Wrapper.m_MyAttActionsCallbackInterface.OnAtt;
                @Att.performed -= m_Wrapper.m_MyAttActionsCallbackInterface.OnAtt;
                @Att.canceled -= m_Wrapper.m_MyAttActionsCallbackInterface.OnAtt;
            }
            m_Wrapper.m_MyAttActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SwordOut.started += instance.OnSwordOut;
                @SwordOut.performed += instance.OnSwordOut;
                @SwordOut.canceled += instance.OnSwordOut;
                @Att.started += instance.OnAtt;
                @Att.performed += instance.OnAtt;
                @Att.canceled += instance.OnAtt;
            }
        }
    }
    public MyAttActions @MyAtt => new MyAttActions(this);

    // Hmp
    private readonly InputActionMap m_Hmp;
    private IHmpActions m_HmpActionsCallbackInterface;
    private readonly InputAction m_Hmp__1;
    private readonly InputAction m_Hmp__2;
    private readonly InputAction m_Hmp__3;
    private readonly InputAction m_Hmp__4;
    private readonly InputAction m_Hmp__5;
    private readonly InputAction m_Hmp__6;
    private readonly InputAction m_Hmp__7;
    private readonly InputAction m_Hmp__8;
    public struct HmpActions
    {
        private @Control m_Wrapper;
        public HmpActions(@Control wrapper) { m_Wrapper = wrapper; }
        public InputAction @_1 => m_Wrapper.m_Hmp__1;
        public InputAction @_2 => m_Wrapper.m_Hmp__2;
        public InputAction @_3 => m_Wrapper.m_Hmp__3;
        public InputAction @_4 => m_Wrapper.m_Hmp__4;
        public InputAction @_5 => m_Wrapper.m_Hmp__5;
        public InputAction @_6 => m_Wrapper.m_Hmp__6;
        public InputAction @_7 => m_Wrapper.m_Hmp__7;
        public InputAction @_8 => m_Wrapper.m_Hmp__8;
        public InputActionMap Get() { return m_Wrapper.m_Hmp; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HmpActions set) { return set.Get(); }
        public void SetCallbacks(IHmpActions instance)
        {
            if (m_Wrapper.m_HmpActionsCallbackInterface != null)
            {
                @_1.started -= m_Wrapper.m_HmpActionsCallbackInterface.On_1;
                @_1.performed -= m_Wrapper.m_HmpActionsCallbackInterface.On_1;
                @_1.canceled -= m_Wrapper.m_HmpActionsCallbackInterface.On_1;
                @_2.started -= m_Wrapper.m_HmpActionsCallbackInterface.On_2;
                @_2.performed -= m_Wrapper.m_HmpActionsCallbackInterface.On_2;
                @_2.canceled -= m_Wrapper.m_HmpActionsCallbackInterface.On_2;
                @_3.started -= m_Wrapper.m_HmpActionsCallbackInterface.On_3;
                @_3.performed -= m_Wrapper.m_HmpActionsCallbackInterface.On_3;
                @_3.canceled -= m_Wrapper.m_HmpActionsCallbackInterface.On_3;
                @_4.started -= m_Wrapper.m_HmpActionsCallbackInterface.On_4;
                @_4.performed -= m_Wrapper.m_HmpActionsCallbackInterface.On_4;
                @_4.canceled -= m_Wrapper.m_HmpActionsCallbackInterface.On_4;
                @_5.started -= m_Wrapper.m_HmpActionsCallbackInterface.On_5;
                @_5.performed -= m_Wrapper.m_HmpActionsCallbackInterface.On_5;
                @_5.canceled -= m_Wrapper.m_HmpActionsCallbackInterface.On_5;
                @_6.started -= m_Wrapper.m_HmpActionsCallbackInterface.On_6;
                @_6.performed -= m_Wrapper.m_HmpActionsCallbackInterface.On_6;
                @_6.canceled -= m_Wrapper.m_HmpActionsCallbackInterface.On_6;
                @_7.started -= m_Wrapper.m_HmpActionsCallbackInterface.On_7;
                @_7.performed -= m_Wrapper.m_HmpActionsCallbackInterface.On_7;
                @_7.canceled -= m_Wrapper.m_HmpActionsCallbackInterface.On_7;
                @_8.started -= m_Wrapper.m_HmpActionsCallbackInterface.On_8;
                @_8.performed -= m_Wrapper.m_HmpActionsCallbackInterface.On_8;
                @_8.canceled -= m_Wrapper.m_HmpActionsCallbackInterface.On_8;
            }
            m_Wrapper.m_HmpActionsCallbackInterface = instance;
            if (instance != null)
            {
                @_1.started += instance.On_1;
                @_1.performed += instance.On_1;
                @_1.canceled += instance.On_1;
                @_2.started += instance.On_2;
                @_2.performed += instance.On_2;
                @_2.canceled += instance.On_2;
                @_3.started += instance.On_3;
                @_3.performed += instance.On_3;
                @_3.canceled += instance.On_3;
                @_4.started += instance.On_4;
                @_4.performed += instance.On_4;
                @_4.canceled += instance.On_4;
                @_5.started += instance.On_5;
                @_5.performed += instance.On_5;
                @_5.canceled += instance.On_5;
                @_6.started += instance.On_6;
                @_6.performed += instance.On_6;
                @_6.canceled += instance.On_6;
                @_7.started += instance.On_7;
                @_7.performed += instance.On_7;
                @_7.canceled += instance.On_7;
                @_8.started += instance.On_8;
                @_8.performed += instance.On_8;
                @_8.canceled += instance.On_8;
            }
        }
    }
    public HmpActions @Hmp => new HmpActions(this);

    // Skill
    private readonly InputActionMap m_Skill;
    private ISkillActions m_SkillActionsCallbackInterface;
    private readonly InputAction m_Skill_F1;
    private readonly InputAction m_Skill_F2;
    private readonly InputAction m_Skill_F3;
    private readonly InputAction m_Skill_F4;
    private readonly InputAction m_Skill_F5;
    private readonly InputAction m_Skill_F6;
    public struct SkillActions
    {
        private @Control m_Wrapper;
        public SkillActions(@Control wrapper) { m_Wrapper = wrapper; }
        public InputAction @F1 => m_Wrapper.m_Skill_F1;
        public InputAction @F2 => m_Wrapper.m_Skill_F2;
        public InputAction @F3 => m_Wrapper.m_Skill_F3;
        public InputAction @F4 => m_Wrapper.m_Skill_F4;
        public InputAction @F5 => m_Wrapper.m_Skill_F5;
        public InputAction @F6 => m_Wrapper.m_Skill_F6;
        public InputActionMap Get() { return m_Wrapper.m_Skill; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SkillActions set) { return set.Get(); }
        public void SetCallbacks(ISkillActions instance)
        {
            if (m_Wrapper.m_SkillActionsCallbackInterface != null)
            {
                @F1.started -= m_Wrapper.m_SkillActionsCallbackInterface.OnF1;
                @F1.performed -= m_Wrapper.m_SkillActionsCallbackInterface.OnF1;
                @F1.canceled -= m_Wrapper.m_SkillActionsCallbackInterface.OnF1;
                @F2.started -= m_Wrapper.m_SkillActionsCallbackInterface.OnF2;
                @F2.performed -= m_Wrapper.m_SkillActionsCallbackInterface.OnF2;
                @F2.canceled -= m_Wrapper.m_SkillActionsCallbackInterface.OnF2;
                @F3.started -= m_Wrapper.m_SkillActionsCallbackInterface.OnF3;
                @F3.performed -= m_Wrapper.m_SkillActionsCallbackInterface.OnF3;
                @F3.canceled -= m_Wrapper.m_SkillActionsCallbackInterface.OnF3;
                @F4.started -= m_Wrapper.m_SkillActionsCallbackInterface.OnF4;
                @F4.performed -= m_Wrapper.m_SkillActionsCallbackInterface.OnF4;
                @F4.canceled -= m_Wrapper.m_SkillActionsCallbackInterface.OnF4;
                @F5.started -= m_Wrapper.m_SkillActionsCallbackInterface.OnF5;
                @F5.performed -= m_Wrapper.m_SkillActionsCallbackInterface.OnF5;
                @F5.canceled -= m_Wrapper.m_SkillActionsCallbackInterface.OnF5;
                @F6.started -= m_Wrapper.m_SkillActionsCallbackInterface.OnF6;
                @F6.performed -= m_Wrapper.m_SkillActionsCallbackInterface.OnF6;
                @F6.canceled -= m_Wrapper.m_SkillActionsCallbackInterface.OnF6;
            }
            m_Wrapper.m_SkillActionsCallbackInterface = instance;
            if (instance != null)
            {
                @F1.started += instance.OnF1;
                @F1.performed += instance.OnF1;
                @F1.canceled += instance.OnF1;
                @F2.started += instance.OnF2;
                @F2.performed += instance.OnF2;
                @F2.canceled += instance.OnF2;
                @F3.started += instance.OnF3;
                @F3.performed += instance.OnF3;
                @F3.canceled += instance.OnF3;
                @F4.started += instance.OnF4;
                @F4.performed += instance.OnF4;
                @F4.canceled += instance.OnF4;
                @F5.started += instance.OnF5;
                @F5.performed += instance.OnF5;
                @F5.canceled += instance.OnF5;
                @F6.started += instance.OnF6;
                @F6.performed += instance.OnF6;
                @F6.canceled += instance.OnF6;
            }
        }
    }
    public SkillActions @Skill => new SkillActions(this);
    public interface IMyControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMoveBack(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnHoldRotate(InputAction.CallbackContext context);
        void OnFast(InputAction.CallbackContext context);
        void OnGetTool(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IMyAttActions
    {
        void OnSwordOut(InputAction.CallbackContext context);
        void OnAtt(InputAction.CallbackContext context);
    }
    public interface IHmpActions
    {
        void On_1(InputAction.CallbackContext context);
        void On_2(InputAction.CallbackContext context);
        void On_3(InputAction.CallbackContext context);
        void On_4(InputAction.CallbackContext context);
        void On_5(InputAction.CallbackContext context);
        void On_6(InputAction.CallbackContext context);
        void On_7(InputAction.CallbackContext context);
        void On_8(InputAction.CallbackContext context);
    }
    public interface ISkillActions
    {
        void OnF1(InputAction.CallbackContext context);
        void OnF2(InputAction.CallbackContext context);
        void OnF3(InputAction.CallbackContext context);
        void OnF4(InputAction.CallbackContext context);
        void OnF5(InputAction.CallbackContext context);
        void OnF6(InputAction.CallbackContext context);
    }
}
