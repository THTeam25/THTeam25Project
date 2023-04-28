using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Boss_AboveThePlayerBullet : MonoBehaviour
{
    private Vector3 initialPosition;   // �I�u�W�F�N�g�̏����ʒu��ێ����邽�߂̕ϐ�
    private float elapsedTime;         // �o�ߎ��Ԃ��v�����邽�߂̕ϐ�
    private Transform playerTransform;//�v���C���[�̈ʒu
    public float chasetime;//�ǐՂ��鎞��
    private int num = 0;
    private Vector3 targetPosition; // �ړ���̈ʒu

    [SerializeField]
    [Tooltip("��������͈�A�̍���̃R���C�_�[")]//�J�[�\�������킹���ې����\��
    private Transform RangeA_leftup;

    [SerializeField]
    [Tooltip("��������͈�A�̉E���̃R���C�_�[")]
    private Transform RangeA_rightdown;

    [SerializeField]
    [Tooltip("��������͈�B�̍���̃R���C�_�[")]//�J�[�\�������킹���ې����\��
    private Transform RangeB_leftup;

    [SerializeField]
    [Tooltip("��������͈�B�̉E���̃R���C�_�[")]
    private Transform RangeB_rightdown;

    // Start is called before the first frame update
    void Start()
    {
        // "Player" �I�u�W�F�N�g���������� Transform �R���|�[�l���g���擾
        playerTransform = GameObject.Find("Player").transform;

        initialPosition = transform.position;  // �I�u�W�F�N�g�̏����ʒu��ۑ�
        num = 0;

        // �R���C�_�[�̃g���K�[���[�h���I���ɂ���
        GetComponent<Collider>().isTrigger = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // �v���C���[�̈ʒu�Ɍ������Ĉړ����邽�߂̖ڕW�ʒu���v�Z����
        targetPosition = new Vector3(initialPosition.x, initialPosition.y, playerTransform.position.z);
        if (num == 0)
        {
            //�͈͓��Ƀv���C���[�������Ă�����
            //if ((RangeA_leftup.position.z <= playerTransform.position.z && playerTransform.position.z <= RangeA_rightdown.position.z)
            //    || (RangeB_leftup.position.z <= playerTransform.position.z && playerTransform.position.z <= RangeB_rightdown.position.z))
            //{
                // �I�u�W�F�N�g��ڕW�ʒu�Ɍ������Ĉړ�����
                transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / chasetime);
            //}

            // �o�ߎ��Ԃ��v�����Achasetime���o�߂�����I�u�W�F�N�g�𗎉�������
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= chasetime)
            {
                // �R���C�_�[�̃g���K�[���[�h���I�t�ɂ���
                GetComponent<Collider>().isTrigger = false;
                // �I�u�W�F�N�g�𗎉�������
                GetComponent<Rigidbody>().useGravity = true;
                num = 1;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            //Boss�̗̑͂̃X�N���v�g
            Boss_HealthManager stage1_Boss_HealthManager = collision.gameObject.GetComponent<Boss_HealthManager>();

            stage1_Boss_HealthManager.TakeDamage(1);
            Destroy(gameObject); //���g���폜
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject); //���g���폜
        }

    }
}
