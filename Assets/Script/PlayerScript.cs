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

    //�Y�W�����v����
    public Vector3 pileJumpVector;
    public float nomalJumpinput;
    //PlayerInput
    public PlayerInput playerInput;

    //�p���[�A�b�v�^�C�v
    public PowerUpScript.PowerUp powerUpType;

    //�W�����v�`���[�W�t���O
    public bool jumpChargeFlag = false;
    //�n��t���O
    public bool isGround;
    //���Ƀg���K�[���Ă��邩
    public bool isPile = false;
    //��������ł��邩
    public bool isSeize = false;

    //���W�b�g�{�f�B
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ�
        Move();


        //�����n��ɂ��Ȃ���΃t���O�I�t
        if(!(isGround || isSeize))
        {
            jumpChargeFlag = false;
        }
        
        if (jumpChargeFlag)
        {
            //�W�����v����
            ChargeJump();
        }
        else 
        {
            jumpValue = 0;
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
        
        transform.Translate(new Vector3(0,0,1) * speed * leftX * Time.deltaTime,Space.World);

        transform.Rotate(new Vector3(1,0,0) * leftX, Space.World);
    }

    //�W�����v�{�^�����b���ꂽ��ꂽ��
    public void OnJump(InputAction.CallbackContext context)
    {

       
 
        //�n�ʂ����ɂ��Ȃ���΃W�����v����
        if (context.performed && (isGround || isSeize))
        {
            

            //�W�����v
            Jump();

            jumpChargeFlag = false;
            jumpValue = 0;
        }
    }

    //�W�����v����
    public void ChargeJump()
    {
        //�n��ɂ���Ԃ������Z
        if(isGround || isSeize)
        {
            //���W�����v�x�N�g���擾
            pileJumpVector.y = playerInput.actions["JumpCharge"].ReadValue<Vector2>().y;
            pileJumpVector.z = playerInput.actions["JumpCharge"].ReadValue<Vector2>().x;
            //���W�����v�x�N�g�����]
            pileJumpVector *= -1;
            //�ʏ�W�����v���͒l
            nomalJumpinput = playerInput.actions["JumpCharge"].ReadValue<Vector2>().magnitude;
        }
        else
        {
            jumpValue = 0.0f;
        }

        
    }
    
    //�W�����v�`���[�W�{�^���������ꂽ��
    public void OnChargeJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //�n�ォ���ɂ���Ԃ���
            if (isGround || isSeize)
            {
                //�t���O�I��
                jumpChargeFlag = true;


            }
            else
            {
                //�t���O�I�t
                jumpChargeFlag = false;

            }

            
        }

    }

    //�W�����v
    void Jump()
    {
        //�x���V�e�B��0�ɂ���
        GetComponent<Rigidbody>().velocity = Vector3.zero;
       
        if (isSeize)
        {
            //���t���O�I�t
            isPile = false;
            //�͂݃t���O�I�t
            isSeize = false;

            ////�R���C�_�[�I�t
            GetComponent<SphereCollider>().enabled = false;

            Invoke("ColiiderEnable", 0.2f);

            //transform.position += Vector3.up * 2;

            //���W�����v
            playerRb.AddForce(pileJumpVector * (jumpPower * pileJumpVector.magnitude) * 1.5f);

            //�q�b�g��������null�ɂ���
            hitPile = null;

            

        }
        else
        {
            
            if(nomalJumpinput <0)
            {
                nomalJumpinput *= -1;
            }


            //�ʏ�W�����v
            playerRb.AddForce(Vector3.up * jumpPower * nomalJumpinput);

            //�n��t���O�I�t
            isGround = false;
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
        GetComponent<SphereCollider>().enabled = true;
    }

    //�͂�
    public void OnSeize(InputAction.CallbackContext context)
    {
        //�{�^���������ꂽ��
        if(context.started)
        {
            //���Ƀg���K�[���Ă��Ē͂�ł��Ȃ���Β͂�
            if (isPile && !isSeize)
            {
                isSeize = true;
            }
            //�͂�ł���Ε���
            else if (isSeize)
            {
                isSeize = false;
            }
        }
        
    }
    
}
