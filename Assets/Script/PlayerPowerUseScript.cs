using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPowerUseScript : MonoBehaviour
{
    //PlayerGameObject
    private GameObject player;
   
    //PlayerScript
    private PlayerScript pS;

    //PowerUp���͒l
    public Vector2 powerInput;

    //�p���[�A�b�v�g�p�t���O
    public bool powerUpFlag = false;
    //�^�C���ňړ����t���O
    public bool tireMoveFlag = false;
    
    //player�̃p���[�A�b�v�^�C�v
    private PowerUpScript.PowerUp powerUpType = PowerUpScript.PowerUp.None;

    //�^�C���i�s����
    public float tireVector = 0.0f;
    //PowerUp�l
    public float powerUpValue = 0.0f;
    //�ő�PowerUp�l
    public float powerUpMaxValue = 180.0f;
    //�^�C���p���[
    public float tirePower = 1000.0f;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        pS = player.GetComponent<PlayerScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //����\�͎g�p
        PowerUse();
    }

    //�p���[�g�p
    private void PowerUse()
    {


        ////�p���[�g�p������Ȃ���ΕԂ�
        if (!powerUpFlag) return;

        //

        switch (powerUpType)
        {
            case PowerUpScript.PowerUp.None:

                break;

            case PowerUpScript.PowerUp.Tire:
                TireCharge();
                break;
        }
    }

    public void OnTireCharge(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //�p���[�g�p���t���O�I��
            powerUpFlag = true;
        }



        //input�擾
        powerInput = context.ReadValue<Vector2>();


    }

    //�^�C���g�p�{�^���������[�X������
    public void RightOnTireUse(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            tireVector = -1;


            //�^�C���g�p
            UseTire();
        }
    }
    public void LeftOnTireUse(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            tireVector = 1;


            //�^�C���g�p
            UseTire();
        }
    }



    //�^�C���\�͗��߂�
    private void TireCharge()
    {


        if (pS.GetIsGround() && powerUpFlag)
        {
            //���Z
            powerUpValue++;

            //�l����
            if (powerUpValue > powerUpMaxValue)
            {
                powerUpValue = powerUpMaxValue;
            }

        }

    }

    //�^�C���\�͎g�p
    private void UseTire()
    {
        //powerUpvalue����
        powerUpValue /= powerUpMaxValue;

        //��΂�
        player.GetComponent<Rigidbody>().AddForce(player.transform.forward * powerUpValue * tirePower * tireVector);


        powerUpFlag = false;
        //������
        powerUpValue = 0.0f;

        Invoke("SetTireMoveFlagFalse", 5.0f);
    }

    //�p���[�A�b�v�t���O��false�ɂ���
    private void SetTireMoveFlagFalse()
    {
        tireMoveFlag = false;

    }

    //�^�C�v��ݒ�
    public void SetPowerType(PowerUpScript.PowerUp t)
    {
        powerUpType = t;
    }
}
