using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Boss_UltraSonic : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;


    public float bulletwait = 1.0f;//�e�̔��ˊԊu
    public float bulletspeed = 10.0f;
    public float attackTime = 10.0f;

    public float time;
    public float timer;
    //private bool isShot = false;//���˃t���O

    //�G�l�~�[�̃��W�b�g�{�f�B
    private Rigidbody enemyRb;

    private float countnum;

    // Start is called before the first frame update
    void Start()
    {
        time = bulletwait;
        timer = attackTime;
        countnum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject manager_Stage2RandomMove = GameObject.Find("Manager_Stage2RandomMove");
        Boss_RamdomMove BRM = manager_Stage2RandomMove.GetComponent<Boss_RamdomMove>();
        if (BRM.behavior2Active == true)
        {
            if(countnum==0)
            {
                timer = attackTime;
                countnum = 1;
            }
            else
            {
                if (timer <= 0)
                {
                    BRM.behavior2Active = false;
                    BRM.behavior3Active = true;
                    countnum = 0;
                }
            }

            Shot();
            timer -= Time.deltaTime;

            
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
            Vector3 vec = transform.position + transform.forward * 1.0f; //�L�����N�^�[�̈ʒu��菭���O
            var shot = Instantiate(bullet, vec, Quaternion.identity);//����
            shot.GetComponent<Rigidbody>().velocity = transform.forward.normalized * bulletspeed;

            time = bulletwait;
        }
    }



}
