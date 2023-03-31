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
        // 最初はmainCameraとminimap~を有効にする
        mainCamera.enabled = true;
        minimapcamera.SetActive(true);
        secondCamera.enabled = false;
    }

        void Update()
    {
        // プレイヤーがカメラ切り替えポイントに到達したら
        if (player.position.z <= cameraChangePoint.position.z + 1.5f && player.position.z >= cameraChangePoint.position.z - 1.5f
            && player.position.y <= cameraChangePoint.position.y + 1.5f && player.position.y >= cameraChangePoint.position.y - 1.5f
            && player.position.x <= cameraChangePoint.position.x + 1.5f && player.position.x >= cameraChangePoint.position.x - 1.5f)
        {
            mainCamera.enabled = !mainCamera.enabled;
            // ゲームオブジェクトを見えなくする
            minimapcamera.SetActive(false);
            secondCamera.enabled = !secondCamera.enabled;
            player.position = cube.transform.position;
        }
    }
}
