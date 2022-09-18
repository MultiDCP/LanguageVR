//========= Copyright 2019, HTC Corporation. All rights reserved. ===========
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ViveSR
{
    namespace anipal
    {
        namespace Lip
        {
            public class SRanipal_Lip_Framework : MonoBehaviour
            {
                public enum FrameworkStatus { STOP, START, WORKING, ERROR }
                /// <summary>
                /// The status of the anipal engine.
                /// </summary>
                public static FrameworkStatus Status { get; protected set; }
                /// <summary>
                /// Whether to enable anipal's Lip module.  -> 입 모듈 모양을 자유롭게 사용 가능하다는 말
                /// </summary>
                public bool EnableLip = true; // 입 모양 움직이는지 안 움직이는지 보는 bool 연산자
                /// <summary>
                /// Currently supported lip motion prediction engine's version.
                /// </summary>
                public enum SupportedLipVersion { version1, version2 }
                /// <summary>
                /// Which version of lip motion prediction engine will be used, default is version 1.
                /// </summary>
                public SupportedLipVersion EnableLipVersion = SupportedLipVersion.version1;

                private static SRanipal_Lip_Framework Mgr = null;
                public static SRanipal_Lip_Framework Instance // Instance -> Mgr
                {
                    get
                    {
                        if (Mgr == null)
                        {
                            Mgr = FindObjectOfType<SRanipal_Lip_Framework>();
                        }
                        if (Mgr == null)
                        {
                            Debug.LogError("SRanipal_Lip_Framework not found");
                        }
                        return Mgr;
                    }
                }

                void Start()
                {
                    StartFramework();
                    //doingButton을 눌렀을 때, Framework가 움직이지 않도록 메서드를 링크시키기.
                    //doingButton.onClick.AddListener(StartFramework);
                   // ParticipateButton.onClick.AddListener(StopFramework);
                }

                void OnDestroy()
                {
                    StopFramework();
                }


                //public Button doingButton, ParticipateButton;

                // 프레임워크가 처음 시작될 때 
                public void StartFramework() 
                {
                    Debug.Log("Successfully Conncected!");
                    if (!EnableLip) return;
                    if (Status == FrameworkStatus.WORKING) return;
                    Status = FrameworkStatus.START; // 프레임워크가 시작되는 상태로 만들어줌. 

                    if (EnableLipVersion == SupportedLipVersion.version1) // version1과 작동하는 있다는 것.
                    {
                        Error result = SRanipal_API.Initial(SRanipal_Lip.ANIPAL_TYPE_LIP, IntPtr.Zero);
                        if (result == Error.WORK)
                        {
                            Debug.Log("[SRanipal] Initial Lip : " + result);
                            Status = FrameworkStatus.WORKING;
                        }
                        else
                        {
                            Debug.LogError("[SRanipal] Initial Lip : " + result);
                            Status = FrameworkStatus.ERROR;
                        }
                    }
                    else
                    {
                        Error result = SRanipal_API.Initial(SRanipal_Lip_v2.ANIPAL_TYPE_LIP_V2, IntPtr.Zero);
                        if (result == Error.WORK)
                        {
                            Debug.Log("[SRanipal] Initial Version 2 Lip : " + result);
                            Status = FrameworkStatus.WORKING;
                        }
                        else
                        {
                            Debug.LogError("[SRanipal] Initial Version 2 Lip : " + result);
                            Status = FrameworkStatus.ERROR;
                        }
                    }
                }

                public void StopFramework()
                {
                    Debug.Log("Successfully DisConncected!");
                    if (Status != FrameworkStatus.STOP)
                    {
                        if (EnableLipVersion == SupportedLipVersion.version1)
                        {
                            Error result = SRanipal_API.Release(SRanipal_Lip.ANIPAL_TYPE_LIP);
                            if (result == Error.WORK) Debug.Log("[SRanipal] Release Lip : " + result);
                            else Debug.LogError("[SRanipal] Release Lip : " + result);
                        }
                        else
                        {
                            Error result = SRanipal_API.Release(SRanipal_Lip_v2.ANIPAL_TYPE_LIP_V2);
                            if (result == Error.WORK) Debug.Log("[SRanipal] Release Version 2 Lip : " + result);
                            else Debug.LogError("[SRanipal] Release Version 2 Lip : " + result);
                        }
                    }
                    else
                    {
                        Debug.Log("[SRanipal] Stop Framework : module not on");
                    }
                    Status = FrameworkStatus.STOP;
                }
            }
        }
    }
}