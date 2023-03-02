using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GomGunScript : MonoBehaviour
{
    //飛ばす力
    public float power = 1.0f;
    

    //PlayerObject
    GameObject player;
    //PlayerScript
    PlayerScript pS;
    //Playerが当たったかのフラグ
    private bool playerFlag = false;
    //発射フラグ
    private bool fire = false;

    public Vector3 forward;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //playerが当たっていたら位置固定
        if(playerFlag)
        {
            //SpawnPointにPlayerを合わせる
            player.transform.position = transform.GetChild(0).gameObject.transform.position;

            if(fire)
            {
                //PlayerのVelocityをゼロに
                player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                //重力切る
                player.GetComponent<Rigidbody>().useGravity = false;
                //Player飛ばす
                player.GetComponent<Rigidbody>().AddForce(transform.forward * power);

                forward = transform.forward;

                //移動できるようにする
                pS.SetMove(true);

                //Playerフラグオフ
                playerFlag = false;

                fire = false;

                //銃設定
                pS.SetHitGun(null);
            }
        }
    }

    //Playerが当たったら
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //コンポーネント設定
            player = collision.gameObject;
            pS = player.GetComponent<PlayerScript>();

            //移動できなくする
            pS.SetMove(false);

            //Playerフラグオン
            playerFlag = true;

            //銃設定
            pS.SetHitGun(this.gameObject);
        }
    }

    //発射ボタンが押されたら
    public void Fire()
    {

        if(playerFlag)
        {
            fire = true;
        }
    }
}
