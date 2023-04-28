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

    //インタラクトできるかのフラグ
    public bool intaractFlag;
    public Image intaractImage;


    //モデル
    public GameObject open;
    public GameObject close;

    void Start()
    {
        // 最初はmainCameraとminimap~を有効にする
        mainCamera.enabled = true;
        minimapcamera.SetActive(true);
        secondCamera.enabled = false;
        bossmoveflag = false;
    }

        void Update()
    {
        // プレイヤーがカメラ切り替えポイントに到達したら
        if (player.position.z <= cameraChangePoint.position.z + 1.5f && player.position.z >= cameraChangePoint.position.z - 1.5f
            && player.position.y <= cameraChangePoint.position.y + 1.5f && player.position.y >= cameraChangePoint.position.y - 1.5f
            && player.position.x <= cameraChangePoint.position.x + 1.5f && player.position.x >= cameraChangePoint.position.x - 1.5f)
        {
            
        }
    }

    //ワープ
    public void Intaract()
    {
        if(intaractFlag)
        {
            mainCamera.enabled = false;
            // ゲームオブジェクトを見えなくする
            minimapcamera.SetActive(false);
            secondCamera.enabled = true;
            player.position = cube.transform.position;
            bossmoveflag = true;
        }
       
    }

    //Playerがトリガーしたか
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            intaractFlag = true;

            //画像表示
            intaractImage.enabled = true;

            //インタラクトフラグ通知をプレイヤーに贈る
            other.gameObject.GetComponent<IntaractChacker>().SetCameraSwitcher(this);

            open.SetActive(true);
            close.SetActive(false);

        }
    }

    //Playerがトリガーから外れたか
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            intaractFlag = false;

            //画像非表示
            intaractImage.enabled = false;

            //インタラクトフラグがfalseになった通知をプレイヤーに贈る
            other.gameObject.GetComponent<IntaractChacker>().SetCameraSwitcher(null);

            open.SetActive(false);
            close.SetActive(true);
        }
    }
}
