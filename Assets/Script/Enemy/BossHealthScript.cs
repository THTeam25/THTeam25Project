using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthScript : MonoBehaviour
{
    //最大HP
    public int maxHP;
    //現在体力
    public int HP;

    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ダメージを与える
    public void TakeDamage(int val)
    {
        HP -= val;

        if(HP <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        GetComponent<ChangeScene>().Change();
        Destroy(gameObject);
    }
}
