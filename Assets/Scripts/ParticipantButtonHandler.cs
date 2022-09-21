using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticipantButtonHandler : MonoBehaviour
{
    public GameObject canvas; // ��ư ĵ����
    public GameObject avatar; // ������
    public GameObject cameraRig; // VR ī�޶� ������
    public Camera vrCamera; // ī�޶� ��ü ������Ʈ

    private void Awake()
    {
        
        vrCamera.cullingMask = vrCamera.cullingMask & ~(1 << LayerMask.NameToLayer("Participant"));
        vrCamera.cullingMask = vrCamera.cullingMask & ~(1 << LayerMask.NameToLayer("Questioner"));
    }

    public void ParticipantButton() // �ƹ�Ÿ�� ���� ������ ������ �ΰ�
    {
        vrCamera.cullingMask |= (1 << LayerMask.NameToLayer("Questioner"));
        
        
        canvas.SetActive(false);
    }

    public void QuestionerButton() // �ƹ�Ÿ�� �Ǿ� ������ ���� ���ϴ� �ΰ�
    {
        vrCamera.cullingMask |= (1 << LayerMask.NameToLayer("Participant"));
        cameraRig.transform.position = avatar.transform.position;
        cameraRig.transform.rotation = avatar.transform.rotation;
        canvas.SetActive(false);
    }
}
