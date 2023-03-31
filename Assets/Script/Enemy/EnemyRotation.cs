using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
   

    //　旋回するターゲット
    [SerializeField]
    private Transform target;
    //　現在の角度
    private float angle;
    //　回転するスピード
    [SerializeField]
    private float rotateSpeed = 180f;
    //　ターゲットからの距離
    [SerializeField]
    private Vector3 distanceFromTarget = new Vector3(0f, 1f, 2f);

    // Update is called once per frame
    void Update()
    {

        //　ユニットの位置 = ターゲットの位置 ＋ ターゲットから見たユニットの角度 ×　ターゲットからの距離
        transform.position = target.position + Quaternion.Euler(angle, 0f, 0f) * distanceFromTarget;
        //　ユニット自身の角度 = ターゲットから見たユニットの方向の角度を計算しそれをユニットの角度に設定する
        transform.rotation = Quaternion.LookRotation(transform.position - new Vector3(target.position.x, transform.position.y, target.position.z), Vector3.up);
        //　ユニットの角度を変更
        angle += rotateSpeed * Time.deltaTime;
        //　角度を0～360度の間で繰り返す
        angle = Mathf.Repeat(angle, 360f);
    }
}
