using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Boss_CreateBullet : MonoBehaviour
{
    public GameObject bullet;
    private GameObject chara;
    Animator animator;
    bool isCapsuleFall = false;
    [SerializeField]
    [Tooltip("��������͈�A")]//�J�[�\�������킹���ې����\��
    private Transform Range_leftup;
    [SerializeField]
    [Tooltip("��������͈�B")]
    private Transform Range_rightdown;

    // �o�ߎ���
    [Tooltip("�e�𐶐�����Ԋu")]
    public float bulletwait;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = bulletwait;
        chara = GameObject.Find("chara2");
        animator = chara.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //������ς���X�N���v�g�擾
        GameObject manager_RandomBullet = GameObject.Find("Manager_RandomBullet");
        Boss_RamdomMove S1B_BR = manager_RandomBullet.GetComponent<Boss_RamdomMove>();


        if (S1B_BR.behavior1Active == true)
        {
            time -= Time.deltaTime;

            if (time <= 0.0f)//time��0�ɂȂ�����
            {
                // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float y = Random.Range(Range_leftup.position.y, Range_rightdown.position.y);
                // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float z = Random.Range(Range_leftup.position.z, Range_rightdown.position.z);

                isCapsuleFall = true;

                // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
                Instantiate(bullet, new Vector3(0.0f, y, z), bullet.transform.rotation);

                // �o�ߎ��ԃ��Z�b�g
                time = bulletwait;
            }
        }
        else if (S1B_BR.behavior1Active == false)
        {
            isCapsuleFall = false;
        }
        //�A�j���[�^�[�R���g���[���[�ݒ�
        animator.SetBool("IsCapsuleFall", isCapsuleFall);
    }
}
