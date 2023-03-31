using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Transform player;
    public Transform cameraChangePoint;
    public Camera mainCamera;
    public GameObject minimapcamera;
    public GameObject cube;
    public Camera secondCamera;

    void Start()
    {
        // �ŏ���mainCamera��minimap~��L���ɂ���
        mainCamera.enabled = true;
        minimapcamera.SetActive(true);
        secondCamera.enabled = false;
    }

        void Update()
    {
        // �v���C���[���J�����؂�ւ��|�C���g�ɓ��B������
        if (player.position.z <= cameraChangePoint.position.z + 1.5f && player.position.z >= cameraChangePoint.position.z - 1.5f
            && player.position.y <= cameraChangePoint.position.y + 1.5f && player.position.y >= cameraChangePoint.position.y - 1.5f
            && player.position.x <= cameraChangePoint.position.x + 1.5f && player.position.x >= cameraChangePoint.position.x - 1.5f)
        {
            mainCamera.enabled = !mainCamera.enabled;
            // �Q�[���I�u�W�F�N�g�������Ȃ�����
            minimapcamera.SetActive(false);
            secondCamera.enabled = !secondCamera.enabled;
            player.position = cube.transform.position;
        }
    }
}
