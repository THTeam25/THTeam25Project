using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Boss_Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Player�̗̑͂̃X�N���v�g
            PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();

            ps.TakeDamage(1);
            Destroy(gameObject); //���g���폜
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject); //���g���폜
        }
    }
}
