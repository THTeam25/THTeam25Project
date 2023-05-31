using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Boss_Tackle : MonoBehaviour
{
    public Transform playerTransform;  // �v���C���[��Transform
    public Transform targetTransform;  // �ړI�n��Transform
    public float playerSpeed = 5f;  // �v���C���[�̍��W�܂ł̈ړ��X�s�[�h
    public float targetSpeed = 2f;  // �ړI�n�܂ł̈ړ��X�s�[�h
    public float timer = 3.0f;

    public bool reachedPlayer = false;  // �v���C���[�̍��W�ɓ��B�������ǂ���
    public bool reachedTarget = false;  // �ړI�n�ɓ��B�������ǂ���

    private GameObject chara;
    Animator animator;
    bool isAttack = false;

    private GameObject healthManager;
    private float time = 0.0f;
    private float countnum;
    private void Start()
    {
        countnum = 0;
        healthManager = GameObject.Find("Manager_Stage2HealthManager ");
        chara = GameObject.Find("chara2");
        animator = chara.GetComponent<Animator>();
        //this.gameObject.GetComponent<CapsuleCollider>().isTrigger = false; ;
    }

    private void Update()
    {
        GameObject manager_Stage2RandomMove = GameObject.Find("Manager_Stage2RandomMove");
        Boss_RamdomMove BRM = manager_Stage2RandomMove.GetComponent<Boss_RamdomMove>();
        if (BRM.behavior3Active == true)
        {
            if (countnum == 0)
            {
                time = timer;
                countnum = 1;
            }

            time -= Time.deltaTime;

            if (!reachedPlayer)  // �v���C���[�̍��W�ɓ��B���Ă��Ȃ��ꍇ
            {
                isAttack = true;
                float step = playerSpeed * Time.deltaTime;  // �ړ��������v�Z����
                transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, step);  // �v���C���[�̍��W�Ɍ������Ĉړ�����

                if (transform.position == playerTransform.position)  // �v���C���[�̍��W�ɓ��B�����ꍇ
                {
                    reachedPlayer = true;  // ���B�t���O�𗧂Ă�
                    isAttack = false;
                }
                if (time <= 0.0f)
                {
                    reachedPlayer = true;//���B���ĂȂ����ǃt���O���Ă�
                    isAttack = false;
                }
            }

            else if (!reachedTarget)  // �ړI�n�ɓ��B���Ă��Ȃ��ꍇ
            {
                float step = targetSpeed * Time.deltaTime;  // �ړ��������v�Z����
                transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, step);  // �ړI�n�Ɍ������Ĉړ�����

                if (transform.position == targetTransform.position)  // �ړI�n�ɓ��B�����ꍇ
                {
                    reachedTarget = true;  // ���B�t���O�𗧂Ă�
                }
            }
            if (reachedTarget)
            {
                BRM.behavior3Active = false;
                BRM.behavior2Active = true;
                countnum = 0;
                reachedTarget = false;
                reachedPlayer = false;
                //this.gameObject.GetComponent<CapsuleCollider>().isTrigger = false; ;
            }
        }
        //�A�j���[�^�[�R���g���[���[�ݒ�
        animator.SetBool("IsAttack", isAttack);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Player�̗̑͂̃X�N���v�g
            PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();

            ps.TakeDamage(1);
            //reachedPlayer = true;// ���B�t���O�𗧂Ă�

        }
        if (collision.gameObject.CompareTag("Screen"))
        {
            reachedPlayer = true;//���B���ĂȂ����ǃt���O���Ă�
            isAttack = false;

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Screen"))
        {
            //Boss�̗̑͂̃X�N���v�g
            Boss_HealthManager stage2_Boss_HealthManager = healthManager.GetComponent<Boss_HealthManager>();

            stage2_Boss_HealthManager.TakeDamage(1);
            //this.gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
        }
    }
}

