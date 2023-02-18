using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    //�ړ����x
    public float speed = 1.0f;
    //���X�e�B�b�N����
    public float leftX = 0;
    //�W�����v��
    public float jumpPower = 1.0f;
    //�W�����v���͒l
    public float jumpValue = 0.0f;
    //�ő�W�����v���͒l
    public float maxJumpValue = 180.0f;
    
    //�q�b�g���Y
    public GameObject hitPile;




    //�p���[�A�b�v�^�C�v
    public PowerUpScript.PowerUp powerUpType;

    //�W�����v�`���[�W�t���O
    public bool jumpChargeFlag = false;
    //�n��t���O
    public bool isGround;
    //���ɂԂ牺�����Ă��邩
    public bool isPile = false;
   

    //���W�b�g�{�f�B
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ�
        Move();

        

        //�W�����v����
        if(jumpChargeFlag)
        {
            ChargeJump();
        }
    }

    public  void OnMove(InputAction.CallbackContext context)
    {
        //���X�e�B�b�N����
        leftX = context.ReadValue<Vector2>().x;

       
    }

    //�ړ�
    void Move()
    {
        
        transform.Translate(Vector3.forward * speed * leftX * Time.deltaTime);
    }

    //�W�����v�����ꂽ��
    public void OnJump(InputAction.CallbackContext context)
    {
        if(isGround || isPile)
        {
            //�W�����v�`���[�W�t���O�I��
            jumpChargeFlag = true;
        }
        else
        {
            //�W�����v�`���[�W�t���O�I�t
            jumpChargeFlag = false;
        }
        



        if(context.performed)
        {
            //�W�����v
            Jump();
        }
    }

    //�W�����v����
    void ChargeJump()
    {
        //�n��ɂ���Ԃ������Z
        if(isGround || isPile)
        {
            //�W�����v���͂����Z
            jumpValue++;

            if (jumpValue > maxJumpValue)
            {
                jumpValue = maxJumpValue;
            }
        }
        else
        {
            //������
            jumpChargeFlag = false;
            jumpValue = 0;
        }
        
    }

    //�W�����v
    void Jump()
    {
        //jumpvalue����
        if (jumpValue > maxJumpValue)
        {
            jumpValue = 1;
        }
        else
        {
            jumpValue = jumpValue / maxJumpValue;
        }

        if(isPile)
        {
            //���t���O�I�t
            isPile = false;
            ////�R���C�_�[�I�t
            GetComponent<BoxCollider>().enabled = false;

            Invoke("ColiiderEnable", 0.2f);

            //transform.position += Vector3.up * 2;

            //���W�����v
            playerRb.AddForce(Vector3.up * jumpPower * 1.5f * jumpValue);
        }
        else
        {
            //�ʏ�W�����v
            playerRb.AddForce(Vector3.up * jumpPower * jumpValue);
        }
        

        //�t���O�I�t
        jumpChargeFlag = false;

        //������
        jumpValue = 0;
    }

    //�����ɓ���������
    private void OnCollisionEnter(Collision collision)
    {
        //�n��ɂ��邩����
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }

        //�p���[�A�b�v�A�C�e���ɓ���������
        if(collision.gameObject.CompareTag("PowerUp"))
        {
            powerUpType = collision.gameObject.GetComponent<PowerUpScript>().type;
            GetComponent<PlayerPowerUseScript>().SetPowerType(powerUpType);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //�n��𗣂ꂽ������
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }

    //�n�ʃt���O�擾
    public bool GetIsGround() { return isGround; }

    //�R���C�_�[�C�l�[�u�� Invoke�p
    private void ColiiderEnable()
    {
        //�R���C�_�[�ݒ�I��
        GetComponent<BoxCollider>().enabled = true;
    }
    
}
