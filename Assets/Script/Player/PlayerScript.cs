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

    //�f�t�H���g�X�P�[��
    private float defaultScaleY;
    //�ʏ�W�����v�̋���
    private float nomalJumpinput;
    //�ő剽�{�܂ŐL�т邩
    public float maxExtend = 3.0f;
    //�ǂꂭ�炢�L�т���
    private float extendValue = 0.0f;
    
    //�R���g���[���[�̓��͏��
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
        //�R���|�[�l���g�擾
        playerRb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        //�X�P�[���擾
        defaultScaleY = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ�
        Move();

        //�����n��ɂ��Ȃ���΃t���O�I�t
        if (!(isGround || isSeize))
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

            //�͂�ł�������͂ɉ�����Player�L�΂�
            if (isSeize && hitPile)
            {
                Extend();
            }

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
       
        if (isSeize)
        {
            //���t���O�I�t
            isPile = false;
            //�͂݃t���O�I�t
            isSeize = false;

            //���W�����v
            playerRb.AddForce(pileJumpVector * (jumpPower * pileJumpVector.magnitude) * 1.5f);

            //�L�΂������ɖ߂�
            FinishExtend();

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

            playerRb.velocity = Vector3.zero;
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
            ////�͂�ł���Ε���
            //else if (isSeize)
            //{
            //    isSeize = false;
            //}
        }
        
    }
    
    //Player�L�΂�
    private void Extend()
    {
        //�������y�X�P�[���v�Z
        extendValue = playerInput.actions["JumpCharge"].ReadValue<Vector2>().magnitude * maxExtend;
        extendValue += 1;
        Vector3 tempScal = transform.localScale;
        tempScal.y = defaultScaleY * extendValue;

        //�X�P�[�����
        transform.localScale = tempScal;

        //���͂ɍ��킹��Player����]
        Vector3 tempRot = new Vector3(0, 90, 0);
        float xinput = playerInput.actions["JumpCharge"].ReadValue<Vector2>().x;
        float yinput = playerInput.actions["JumpCharge"].ReadValue<Vector2>().y;

        tempRot.z = Mathf.Atan2(xinput, yinput) * Mathf.Rad2Deg;

        transform.RotateAround(hitPile.transform.position,new Vector3(0,0,1), tempRot.z);

        transform.rotation = Quaternion.Euler(tempRot);
    }

    //Player�L�΂��I��
    private void FinishExtend()
    {
        Vector3 tempscal = transform.localScale;
        tempscal.y = defaultScaleY;

        //Player�̃X�P�[�������ɖ߂�
        transform.localScale = tempscal;
        //�������킹��y�X�P�[����1�ɖ߂�
        extendValue = 1;

        //�p�x�����ɖ߂�
        Vector3 tempRot = transform.rotation.eulerAngles;
        tempRot.z = 0;
        transform.rotation = Quaternion.Euler(tempRot);

    }

    //�ǂꂭ�炢�L�т����Ԃ�
    public float GetExtendValue() { return extendValue; }
}