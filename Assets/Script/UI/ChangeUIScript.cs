using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class ChangeUIScript : MonoBehaviour
{
    //���\������UI
    public GameObject nextUI;
    //���ŏ��ɑI������{�^��
    public GameObject nextButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //�X�^�[�g��������
    public void OnStart(InputAction.CallbackContext context)
    {
        

        if (context.performed && gameObject.active)
        {
            //��\��
            gameObject.SetActive(false);

            //����UI��\��
            nextUI.SetActive(true);

            //�C�x���g�V�X�e���ɍŏ��ɑI�����Ă���{�^����ݒ�
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(nextButton);
        }
    }

    //�{�^����������UI�؂�ւ�
    public void OnStart()
    {
       

        //��\��
        gameObject.transform.parent.gameObject.SetActive(false);

        //����UI��\��
        nextUI.SetActive(true);

        //�C�x���g�V�X�e���ɍŏ��ɑI�����Ă���{�^����ݒ�
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(nextButton);
    }
}
