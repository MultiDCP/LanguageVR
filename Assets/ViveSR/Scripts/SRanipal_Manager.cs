using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SRanipal_Manager : MonoBehaviour
{
    // 빈 게임오브젝트를 하나 생성.
    GameObject obj;
		
	// doing_btn = 말을 하는 실험자 
	// particapate_btn = 입모양을 보고 무슨 말을 했는지 맞추는 실험자
    public GameObject doing_btn, participate_btn;
	// SRanipal_Lip_Framework 안의 스크립트를 가져오기 위해 선언.
    //public SRanipal_Lip_Framework sranipal_lip_framework_script;
	// doing_btn을 눌렀을 때, 실행이 되는가
	public bool buttonisClicked = true;

    void Start()
    {
        // 오브젝트의 이름을 검색. 
        obj = GameObject.Find("SRanipal Lip Framework");
        // 해당 오브젝트의 public 으로 선언된 변수의 경우 수정 가능
        //obj.GetComponent<SRanipal_Lip_Framework>();
    }

    void Update()
    {
        // 버튼이 클릭되었는지 확인하기.
        if(buttonisClicked)
        {
            Debug.Log("BTN DOWN");
        }
    }

    // doing이라는 버튼을 눌렀을 때, 
    //AvatarSample 안의 Avatar_Shieh_V2 모델이 입모양과 눈 모양을 움직이도록 하기.
    public void OnButtonClick()
    {
        if(buttonisClicked)
        {
            Debug.Log("SRanipal_Lip_Framework is working!");
            //sranipal_lip_framework_script.EnableLip;
        }
        else
        {
            Debug.LogError("SRanipal_Lip_Framework not found");
        }
    }

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