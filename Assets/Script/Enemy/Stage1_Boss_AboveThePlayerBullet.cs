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

    // Start is called before the first frame update
    void Start()
    {
        // "Player" �I�u�W�F�N�g���������� Transform �R���|�[�l���g���擾
        playerTransform = GameObject.Find("Player").transform;

        initialPosition = transform.position;  // �I�u�W�F�N�g�̏����ʒu��ۑ�
        num = 0;

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // �v���C���[�̈ʒu�Ɍ������Ĉړ����邽�߂̖ڕW�ʒu���v�Z����
        targetPosition = new Vector3(initialPosition.x, initialPosition.y, playerTransform.position.z);
        if (num == 0)
        {
            // �I�u�W�F�N�g��ڕW�ʒu�Ɍ������Ĉړ�����
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / chasetime);

            // �o�ߎ��Ԃ��v�����Achasetime���o�߂�����I�u�W�F�N�g�𗎉�������
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= chasetime)
            {
                // �I�u�W�F�N�g�𗎉�������
                GetComponent<Rigidbody>().useGravity = true;
                num = 1;
            }
        }

        if (this.transform.position.y <= 2.0f) //y���W��1�ȉ��ɂȂ�����
        {
            Destroy(gameObject); //���g���폜
        }
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
    }
}
