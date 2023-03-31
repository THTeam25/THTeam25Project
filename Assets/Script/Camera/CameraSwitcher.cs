using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Transform player;
    public Transform cameraChangePoint;
    public Camera mainCamera;
    public Camera secondCamera;

    void Start()
    {
        // �ŏ���mainCamera��L���ɂ���
        mainCamera.enabled = true;
        secondCamera.enabled = false;
    }

        void Update()
    {
        // �v���C���[���J�����؂�ւ��|�C���g�ɓ��B������
        if (player.position.z <= cameraChangePoint.position.z + 0.5f && player.position.z >= cameraChangePoint.position.z - 0.5f
            && player.position.y <= cameraChangePoint.position.y + 0.5f && player.position.y >= cameraChangePoint.position.y - 0.5f)
        {
            mainCamera.enabled = !mainCamera.enabled;
            secondCamera.enabled = !secondCamera.enabled;
            player.position = new Vector3(0, 1.5f, -7);
        }
    }
}
