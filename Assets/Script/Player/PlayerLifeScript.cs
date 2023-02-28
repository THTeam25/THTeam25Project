using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeScript : MonoBehaviour
{
    //�ő�̗�
    public float maxLife = 1;
    //���ݑ̗�
    public float life;
    //���S�t���O
    private bool death = false;


    // Start is called before the first frame update
    void Start()
    {
        //�̗͏�����
        life = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�_���[�W����
    public void TakeDamage(int i)
    {
        //�̗͂������
        life -= i;

        //�̗͂�0�ȉ��ɂȂ�����
        if(life <= 0 && !death)
        {
            Death();
        }
    }

    //���S����
    void Death()
    {
        //���S�t���O
        death = true;

        GetComponent<MeshRenderer>().enabled = false;
    }

    //���S�t���O�擾
    public bool GetDeath() { return death; }
}
