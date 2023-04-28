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

    [SerializeField]
    [Tooltip("生成する範囲Aの左上のコライダー")]//カーソルを合わせた際説明表示
    private Transform RangeA_leftup;

    [SerializeField]
    [Tooltip("生成する範囲Aの右下のコライダー")]
    private Transform RangeA_rightdown;

    [SerializeField]
    [Tooltip("生成する範囲Bの左上のコライダー")]//カーソルを合わせた際説明表示
    private Transform RangeB_leftup;

    [SerializeField]
    [Tooltip("生成する範囲Bの右下のコライダー")]
    private Transform RangeB_rightdown;

    // Start is called before the first frame update
    void Start()
    {
        // "Player" オブジェクトを検索して Transform コンポーネントを取得
        playerTransform = GameObject.Find("Player").transform;

        initialPosition = transform.position;  // オブジェクトの初期位置を保存
        num = 0;

        // コライダーのトリガーモードをオンにする
        GetComponent<Collider>().isTrigger = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // プレイヤーの位置に向かって移動するための目標位置を計算する
        targetPosition = new Vector3(initialPosition.x, initialPosition.y, playerTransform.position.z);
        if (num == 0)
        {
            //範囲内にプレイヤーが入っていたら
            //if ((RangeA_leftup.position.z <= playerTransform.position.z && playerTransform.position.z <= RangeA_rightdown.position.z)
            //    || (RangeB_leftup.position.z <= playerTransform.position.z && playerTransform.position.z <= RangeB_rightdown.position.z))
            //{
                // オブジェクトを目標位置に向かって移動する
                transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / chasetime);
            //}

            // 経過時間を計測し、chasetime分経過したらオブジェクトを落下させる
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= chasetime)
            {
                // コライダーのトリガーモードをオフにする
                GetComponent<Collider>().isTrigger = false;
                // オブジェクトを落下させる
                GetComponent<Rigidbody>().useGravity = true;
                num = 1;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            //Bossの体力のスクリプト
            Boss_HealthManager stage1_Boss_HealthManager = collision.gameObject.GetComponent<Boss_HealthManager>();

            stage1_Boss_HealthManager.TakeDamage(1);
            Destroy(gameObject); //自身を削除
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject); //自身を削除
        }

    }
}
