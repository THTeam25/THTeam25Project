using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileColliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Player�Ƃ̓����蔻��
    private void OnCollisionEnter(Collision collision)
    {
        

        if(collision.gameObject.CompareTag("Player"))
        {
            

            //Player�̗̑͂̃X�N���v�g
            PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();

            //Player�փ_���[�W
            ps.TakeDamage(1);

            //�I�u�W�F�N�g�폜
            Destroy(transform.parent.gameObject);
        }
    }
}
