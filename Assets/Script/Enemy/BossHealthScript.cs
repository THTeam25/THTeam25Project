using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthScript : MonoBehaviour
{
    //�ő�HP
    public int maxHP;
    //���ݑ̗�
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

    //�_���[�W��^����
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
