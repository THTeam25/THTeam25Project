using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Boss_AboveThePlayerBulletCreate : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField]
    [Tooltip("�v���C���[")]//�J�[�\�������킹���ې����\��
    private Transform Player;

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

    // �o�ߎ���
    [Tooltip("�e�𐶐�����Ԋu")]
    public float bulletwait;

    private float time;
    

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //������ς���X�N���v�g�擾
        GameObject manager_RandomBullet = GameObject.Find("Manager_RandomBullet");
        Stage1_Boss_RamdomBullet S1B_BR = manager_RandomBullet.GetComponent<Stage1_Boss_RamdomBullet>();

        if (S1B_BR.behavior2Active == true)
        {
            time -= Time.deltaTime;

            //���͈͓̔��Ƀv���C���[�������Ă�����
            if (RangeA_leftup.position.z <= Player.position.z && Player.position.z <= RangeA_rightdown.position.z)
            {
                if (time <= 0.0f)//time��0�ɂȂ�����
                {
                    // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
                    float y = Random.Range(RangeA_leftup.position.y, RangeA_rightdown.position.y);
                    // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
                    float z = Player.position.z;

                    // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
                    GameObject instance = Instantiate(bullet, new Vector3(0.0f, y, z), bullet.transform.rotation);

                    // �ԐF�ɕύX����
                    instance.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);

                    // �o�ߎ��ԃ��Z�b�g
                    time = bulletwait;
                }
            }
            //�E�͈͓̔��Ƀv���C���[�������Ă�����
            if (RangeB_leftup.position.z <= Player.position.z && Player.position.z <= RangeB_rightdown.position.z)
            {
                if (time <= 0.0f)//time��0�ɂȂ�����
                {
                    // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
                    float y = Random.Range(RangeB_leftup.position.y, RangeB_rightdown.position.y);
                    // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
                    float z = Player.position.z;


                    // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
                    GameObject instance = Instantiate(bullet, new Vector3(0.0f, y, z), bullet.transform.rotation);

                    // �ԐF�ɕύX����
                    instance.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);

                    // �o�ߎ��ԃ��Z�b�g
                    time = bulletwait;
                }

            }
        }
        



    }
}