using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GomGunScript : MonoBehaviour
{
    //��΂���
    public float power = 1.0f;
    

    //PlayerObject
    GameObject player;
    //PlayerScript
    PlayerScript pS;
    //Player�������������̃t���O
    private bool playerFlag = false;
    //���˃t���O
    private bool fire = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //player���������Ă�����ʒu�Œ�
        if(playerFlag)
        {
            //SpawnPoint��Player�����킹��
            player.transform.position = transform.GetChild(0).gameObject.transform.position;

            if(fire)
            {
                //Player��΂�
                player.GetComponent<Rigidbody>().AddForce((Vector3.forward + new Vector3(0, 1.0f, 0)) * power);

                //�ړ��ł���悤�ɂ���
                pS.SetMove(true);

                //Player�t���O�I�t
                playerFlag = false;

                fire = false;

                //�e�ݒ�
                pS.SetHitGun(null);
            }
        }
    }

    //Player������������
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //�R���|�[�l���g�ݒ�
            player = collision.gameObject;
            pS = player.GetComponent<PlayerScript>();

            //�ړ��ł��Ȃ�����
            pS.SetMove(false);

            //Player�t���O�I��
            playerFlag = true;

            //�e�ݒ�
            pS.SetHitGun(this.gameObject);
        }
    }

    //���˃{�^���������ꂽ��
    public void Fire()
    {
        Debug.Log("Fire");

        if(playerFlag)
        {
            fire = true;
        }
    }
}
