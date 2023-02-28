using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeScript : MonoBehaviour
{
    //最大体力
    public float maxLife = 1;
    //現在体力
    public float life;
    //死亡フラグ
    private bool death = false;


    // Start is called before the first frame update
    void Start()
    {
        //体力初期化
        life = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ダメージ処理
    public void TakeDamage(int i)
    {
        //体力から引く
        life -= i;

        //体力が0以下になったら
        if(life <= 0 && !death)
        {
            Death();
        }
    }

    //死亡処理
    void Death()
    {
        //死亡フラグ
        death = true;

        GetComponent<MeshRenderer>().enabled = false;
    }

    //死亡フラグ取得
    public bool GetDeath() { return death; }
}
