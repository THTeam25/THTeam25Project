using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthScript : MonoBehaviour
{
    //Å‘åHP
    public int maxHP;
    //Œ»İ‘Ì—Í
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

    //ƒ_ƒ[ƒW‚ğ—^‚¦‚é
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
