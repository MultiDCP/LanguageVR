using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacialManager : MonoBehaviour
{   
    public GameObject doing_btn, participate_btn;
    public bool isWorking = true;

    // doing이라는 버튼을 눌렀을 때, AvatarSample 안의 Avatar_Shieh_V2 모델이 입모양과 눈 모양을 움직이도록 하기.
     
    // public static SRanipal_Lip_Framework Instance;

    // private void Awake()
    // {
    //     sranipal_avatareyesample_v2_script = GameObject.Find("Doing").GetComponent<SRanipal_Eye_Framework>();
    //     sranipal_avatarlipsample_v2_script = GameObject.Find("Participate").GetComponent<SRanipal_Lip_Framework>();
    // }

    // void Start()
    // {
    //     sranipal_avatareyesample_v2_script.GetComponent<SRanipal_Eye_Framework>();
    //     sranipal_avatarlipsample_v2_script.GetComponent<SRanipal_Lip_Framework>();
    //     DoingRoom();
    // }

    // void Update()
    // {
        
    // }

    // public void DoingRoom()
    // {
    //     if(doing_btn == isWorking)
    //     {
    //         if (sranipal_avatareyesample_v2_script.Status == sranipal_avatareyesample_v2_script.FrameworkStatus.WORKING) return;
    //             sranipal_avatareyesample_v2_script.Status = sranipal_avatareyesample_v2_script.FrameworkStatus.START; // 프레임워크가 시작되는 상태로 만들어줌. 
    //     }
    //     else
    //     {
    //         sranipal_avatareyesample_v2_script.Status = sranipal_avatareyesample_v2_script.FrameworkStatus.STOP;
    //     }
    // }

    // 참여자 버튼을 눌렀을 때, 방 참가. 
    // 1. 어떤 단어를 말했는지를 선택할 수 있는 패널을 띄워줌.
    // 2. 패널에서 올바른 단어를 선택 후 '다음'버튼을 클릭 시 진행.

    // public void ParticiapteRoom()
    // {
    //     if(participate_btn == isWorking)
    //     {
                // 실험에 참가하는 인터랙션
    //     }
    //
    //}
}