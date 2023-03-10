using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationEnemy : MonoBehaviour
{
    #region//�C���X�y�N�^�[�Őݒ肷��
    
    
    [SerializeField] [Header("��]��")] private Transform target;
    //�@���݂̊p�x
    private float angle;
    //�@��]����X�s�[�h
    [Header("�X�s�[�h")]
    [SerializeField]
    private float rotateSpeed = 180f;
    //�@�^�[�Q�b�g����̋���
    [Header("���a Z�Œ���")]
    [SerializeField]
    private Vector3 distanceFromTarget = new Vector3(0f, 1f, 2f);
    #endregion

    #region//�v���C�x�[�g�ϐ�
   
    #endregion



    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        //�@���j�b�g�̈ʒu = �^�[�Q�b�g�̈ʒu �{ �^�[�Q�b�g���猩�����j�b�g�̊p�x �~�@�^�[�Q�b�g����̋���
        transform.position = target.position + Quaternion.Euler(angle, 0,0) * distanceFromTarget;
        //�@���j�b�g���g�̊p�x = �^�[�Q�b�g���猩�����j�b�g�̕����̊p�x���v�Z����������j�b�g�̊p�x�ɐݒ肷��
        transform.rotation = Quaternion.LookRotation(transform.position - new Vector3(target.position.x, transform.position.y, 0), Vector3.up);
        //�@���j�b�g�̊p�x��ύX
        angle += rotateSpeed * Time.deltaTime;
        //�p�x��0�`360�x�̊ԂŌJ��Ԃ�
        angle = Mathf.Repeat(angle, 360f);
    }

   
}
