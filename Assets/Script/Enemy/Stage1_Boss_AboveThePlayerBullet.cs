using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Boss_AboveThePlayerBullet : MonoBehaviour
{
    private Vector3 initialPosition;   // オブジェクトの初期位置を保持するための変数
    private float elapsedTime;         // 経過時間を計測するための変数
    private Transform playerTransform;//プレイヤーの位置
    public float chasetime;//追跡する時間
    private int num = 0;
    private Vector3 targetPosition; // 移動先の位置

    // Start is called before the first frame update
    void Start()
    {
        // "Player" オブジェクトを検索して Transform コンポーネントを取得
        playerTransform = GameObject.Find("Player").transform;

        initialPosition = transform.position;  // オブジェクトの初期位置を保存
        num = 0;

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // プレイヤーの位置に向かって移動するための目標位置を計算する
        targetPosition = new Vector3(initialPosition.x, initialPosition.y, playerTransform.position.z);
        if (num == 0)
        {
            // オブジェクトを目標位置に向かって移動する
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / chasetime);

            // 経過時間を計測し、chasetime分経過したらオブジェクトを落下させる
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= chasetime)
            {
                // オブジェクトを落下させる
                GetComponent<Rigidbody>().useGravity = true;
                num = 1;
            }
        }

        if (this.transform.position.y <= 2.0f) //y座標が1以下になったら
        {
            Destroy(gameObject); //自身を削除
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Playerの体力のスクリプト
            PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();

            ps.TakeDamage(1);
            Destroy(gameObject); //自身を削除
        }
    }
}
