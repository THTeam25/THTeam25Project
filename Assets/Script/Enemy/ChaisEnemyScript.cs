using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//追跡する敵用のスクリプト
public class ChaisEnemyScript : MonoBehaviour
{
    //追跡フラグ
    private bool isChais = false;

    //移動スピード
    public float speed = 1.0f;

    //初期位置
    private Vector3 defaultLocation;

    //PlayerObject
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //初期位置設定
        defaultLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //追跡
        Chais();
    }

    //追跡フラグ設定
    public void SetChais(bool b)
    {
        isChais = b;
    }

    //PlayerObject設定
    public void SetPlayer(GameObject g)
    {
        player = g;
    }

    //追跡
    void Chais()
    {
        if(isChais && !player.GetComponent<PlayerLifeScript>().GetDeath())
        {
            //追跡
            //移動ベクトル
            Vector3 moveVec = player.transform.position - transform.position;
            moveVec.Normalize();


            //移動
            transform.Translate(moveVec * speed * Time.deltaTime,Space.World);
        }
        else
        {
            //元の位置に戻る
            //移動ベクトル
            Vector3 moveVec = defaultLocation - transform.position;
            moveVec.Normalize();

            //移動
            transform.Translate(moveVec * speed * Time.deltaTime, Space.World);
        }
    }
}
