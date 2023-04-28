using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_RamdomMove : MonoBehaviour
{
    [SerializeField]
    public bool behavior1Active = false;
    [SerializeField]
    public bool behavior2Active = false;
    [SerializeField]
    public bool behavior3Active = false;
    [SerializeField]
    public bool behavior4Active = false;

    public int stageNo = 0;

    [SerializeField]
    private float timer = 0f;
    [SerializeField]
    private float behaviorDuration = 10f;

    //private int randomBehavior = 0;
    private int startnum;

    private void Start()
    {
        startnum = 0;

    }

    private void Update()
    {

        GameObject cameraChangePoint_Boss = GameObject.Find("CameraChangePoint_Boss");
        CameraSwitcher CS = cameraChangePoint_Boss.GetComponent<CameraSwitcher>();
        if (CS.bossmoveflag == true)
        {
            if (stageNo == 1)
            {
                Stage1Active();
            }

            else if (stageNo == 2)
            {
                Stage2Active();
            }

        }
    }

    // �������A�N�e�B�u�ɂ���
    private void ActivateBehavior(int behavior)
    {
        switch (behavior)
        {
            case 2:
                behavior2Active = true;
                break;
            case 3:
                behavior3Active = true;
                break;
            case 4:
                behavior4Active = true;
                break;
        }
    }

    private void Stage1Active()
    {

        if (startnum == 0)
        {
            // ����1��������
            behavior1Active = true;
            startnum = 1;
        }
        // �^�C�}�[���X�V
        timer += Time.deltaTime;

        // ����1�����s
        if (behavior1Active)
        {
            // 2-5�b�o�����狓��2�����s
            float behavior2Activetimer = Random.Range(2.0f, 5.0f);
            if (timer >= behavior2Activetimer)
            {
                behavior2Active = true;

            }
            if (timer >= behaviorDuration)
            {
                behavior1Active = false;
                behavior2Active = false;
                timer = 0f;

                // �����_���ɋ���2
                behavior1Active = false;
                behavior2Active = false;
            }
        }
        // ����3�����s
        else if (behavior3Active)
        {
            if (timer >= behaviorDuration)
            {
                behavior3Active = false;
                timer = 0f;

                // ����1���ĊJ
                behavior1Active = true;
            }
        }
        // ����4�����s
        else if (behavior4Active)
        {
            if (timer >= behaviorDuration)
            {
                behavior4Active = false;
                timer = 0f;

                // ����1���ĊJ
                behavior1Active = true;
            }
        }

        //// 5����1�̊m���ŋ���2�����s
        //if (behavior1Active && !behavior2Active && Random.Range(0f, 1f) < 0.2f)
        //{
        //    behavior1Active = false;
        //    behavior2Active = true;
        //    timer = 0f;
        //}
    }
    private void Stage2Active()//2�͎��Ԃ���Ȃ��A�X�̃X�N���v�g�Ő���
    {

        if (startnum == 0)
        {
            // ����1��������
            behavior1Active = true;
            startnum = 1;
        }
        // �^�C�}�[���X�V
        timer += Time.deltaTime;
    }
}

