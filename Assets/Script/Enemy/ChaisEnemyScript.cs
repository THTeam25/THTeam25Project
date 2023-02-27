using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ǐՂ���G�p�̃X�N���v�g
public class ChaisEnemyScript : MonoBehaviour
{
    //�ǐՃt���O
    private bool isChais = false;

    //�ړ��X�s�[�h
    public float speed = 1.0f;

    //�����ʒu
    private Vector3 defaultLocation;

    //PlayerObject
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //�����ʒu�ݒ�
        defaultLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //�ǐ�
        Chais();
    }

    //�ǐՃt���O�ݒ�
    public void SetChais(bool b)
    {
        isChais = b;
    }

    //PlayerObject�ݒ�
    public void SetPlayer(GameObject g)
    {
        player = g;
    }

    //�ǐ�
    void Chais()
    {
        if(isChais && !player.GetComponent<PlayerLifeScript>().GetDeath())
        {
            //�ǐ�
            //�ړ��x�N�g��
            Vector3 moveVec = player.transform.position - transform.position;
            moveVec.Normalize();


            //�ړ�
            transform.Translate(moveVec * speed * Time.deltaTime,Space.World);
        }
        else
        {
            //���̈ʒu�ɖ߂�
            //�ړ��x�N�g��
            Vector3 moveVec = defaultLocation - transform.position;
            moveVec.Normalize();

            //�ړ�
            transform.Translate(moveVec * speed * Time.deltaTime, Space.World);
        }
    }
}
