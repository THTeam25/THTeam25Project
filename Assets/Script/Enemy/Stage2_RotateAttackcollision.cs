using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_RotateAttackcollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �R���C�_�[�̃g���K�[���[�h���I���ɂ���
        GetComponent<Collider>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject manager_Stage2RandomMove = GameObject.Find("Manager_Stage2RandomMove");
        Boss_RamdomMove BRM = manager_Stage2RandomMove.GetComponent<Boss_RamdomMove>();
        if (BRM.behavior1Active == true)
        {
            // �R���C�_�[�̃g���K�[���[�h���I�t�ɂ���
            GetComponent<Collider>().isTrigger = false;
        }
        else
        {
            // �R���C�_�[�̃g���K�[���[�h���I���ɂ���
            GetComponent<Collider>().isTrigger = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();
            ps.TakeDamage(1);
        }
    }
}
