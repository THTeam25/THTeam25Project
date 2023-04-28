using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    public Transform player;
    public Transform cameraChangePoint;
    public Camera mainCamera;
    public GameObject minimapcamera;
    public GameObject cube;
    public Camera secondCamera;
    public bool bossmoveflag;

    //�C���^���N�g�ł��邩�̃t���O
    public bool intaractFlag;
    public Image intaractImage;


    //���f��
    public GameObject open;
    public GameObject close;

    void Start()
    {
        // �ŏ���mainCamera��minimap~��L���ɂ���
        mainCamera.enabled = true;
        minimapcamera.SetActive(true);
        secondCamera.enabled = false;
        bossmoveflag = false;
    }

        void Update()
    {
        // �v���C���[���J�����؂�ւ��|�C���g�ɓ��B������
        if (player.position.z <= cameraChangePoint.position.z + 1.5f && player.position.z >= cameraChangePoint.position.z - 1.5f
            && player.position.y <= cameraChangePoint.position.y + 1.5f && player.position.y >= cameraChangePoint.position.y - 1.5f
            && player.position.x <= cameraChangePoint.position.x + 1.5f && player.position.x >= cameraChangePoint.position.x - 1.5f)
        {
            
        }
    }

    //���[�v
    public void Intaract()
    {
        if(intaractFlag)
        {
            mainCamera.enabled = false;
            // �Q�[���I�u�W�F�N�g�������Ȃ�����
            minimapcamera.SetActive(false);
            secondCamera.enabled = true;
            player.position = cube.transform.position;
            bossmoveflag = true;
        }
       
    }

    //Player���g���K�[������
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            intaractFlag = true;

            //�摜�\��
            intaractImage.enabled = true;

            //�C���^���N�g�t���O�ʒm���v���C���[�ɑ���
            other.gameObject.GetComponent<IntaractChacker>().SetCameraSwitcher(this);

            open.SetActive(true);
            close.SetActive(false);

        }
    }

    //Player���g���K�[����O�ꂽ��
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            intaractFlag = false;

            //�摜��\��
            intaractImage.enabled = false;

            //�C���^���N�g�t���O��false�ɂȂ����ʒm���v���C���[�ɑ���
            other.gameObject.GetComponent<IntaractChacker>().SetCameraSwitcher(null);

            open.SetActive(false);
            close.SetActive(true);
        }
    }
}
