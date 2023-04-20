using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Boss_ChasePlayerBullet : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;


    public float bulletwait = 1.0f;//�e�̔��ˊԊu
    public float bulletspeed = 10.0f;

    private float time;

    //�G�l�~�[�̃��W�b�g�{�f�B
    private Rigidbody enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        time = bulletwait;
        
    }

    // Update is called once per frame
    void Update()
    {
        //������ς���X�N���v�g�擾
        GameObject manager_RandomBullet = GameObject.Find("Manager_RandomBullet");
        Boss_RamdomMove S1B_BR = manager_RandomBullet.GetComponent<Boss_RamdomMove>();

        if (S1B_BR.behavior3Active == true)
        {
            Shot();
        }
         
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Player�̗̑͂̃X�N���v�g
            PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();

            ps.TakeDamage(1);
        }
    }

    void Shot()
    {
        transform.LookAt(player.transform);//�v���C���[�̕���������������
        time -= Time.deltaTime;

        if (time <= 0)//�^�C����0�ɂȂ�����
        {
            //�e���o��������n�_
            Vector3 vec = transform.position + transform.forward * 0.5f; //�L�����N�^�[�̈ʒu��菭���O
            var shot = Instantiate(bullet, vec, Quaternion.identity);//����
            shot.GetComponent<Rigidbody>().velocity = transform.forward.normalized * bulletspeed;

            time = bulletwait;
        }
    }

    //���˃t���O�ݒ�
}
