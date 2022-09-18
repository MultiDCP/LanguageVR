using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticipantButtonHandler : MonoBehaviour
{
    public GameObject canvas; // 버튼 캔버스
    public GameObject avatar; // 빡빡이
    public GameObject cameraRig; // VR 카메라 오리진
    public Camera vrCamera; // 카메라 자체 컴포넌트

    private void Awake()
    {
        
        vrCamera.cullingMask = vrCamera.cullingMask & ~(1 << LayerMask.NameToLayer("Participant"));
        vrCamera.cullingMask = vrCamera.cullingMask & ~(1 << LayerMask.NameToLayer("Questioner"));
    }

    public void ParticipantButton() // 아바타를 보며 정답을 맞히는 인간
    {
        vrCamera.cullingMask |= (1 << LayerMask.NameToLayer("Questioner"));
        
        
        canvas.SetActive(false);
    }

    public void QuestionerButton() // 아바타가 되어 정답을 보고 말하는 인간
    {
        vrCamera.cullingMask |= (1 << LayerMask.NameToLayer("Participant"));
        cameraRig.transform.position = avatar.transform.position;
        cameraRig.transform.rotation = avatar.transform.rotation;
        canvas.SetActive(false);
    }
}
