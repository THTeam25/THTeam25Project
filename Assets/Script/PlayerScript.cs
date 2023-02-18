using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    //移動速度
    public float speed = 1.0f;
    //左スティック入力
    public float leftX = 0;
    //ジャンプ力
    public float jumpPower = 1.0f;
    //ジャンプ入力値
    public float jumpValue = 0.0f;
    //最大ジャンプ入力値
    public float maxJumpValue = 180.0f;
    
    //ヒット下杭
    public GameObject hitPile;




    //パワーアップタイプ
    public PowerUpScript.PowerUp powerUpType;

    //ジャンプチャージフラグ
    public bool jumpChargeFlag = false;
    //地上フラグ
    public bool isGround;
    //柱にぶら下がっているか
    public bool isPile = false;
   

    //リジットボディ
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //移動
        Move();

        

        //ジャンプため
        if(jumpChargeFlag)
        {
            ChargeJump();
        }
    }

    public  void OnMove(InputAction.CallbackContext context)
    {
        //左スティック入力
        leftX = context.ReadValue<Vector2>().x;

       
    }

    //移動
    void Move()
    {
        
        transform.Translate(Vector3.forward * speed * leftX * Time.deltaTime);
    }

    //ジャンプ押されたら
    public void OnJump(InputAction.CallbackContext context)
    {
        if(isGround || isPile)
        {
            //ジャンプチャージフラグオン
            jumpChargeFlag = true;
        }
        else
        {
            //ジャンプチャージフラグオフ
            jumpChargeFlag = false;
        }
        



        if(context.performed)
        {
            //ジャンプ
            Jump();
        }
    }

    //ジャンプため
    void ChargeJump()
    {
        //地上にいる間だけ加算
        if(isGround || isPile)
        {
            //ジャンプ入力ち加算
            jumpValue++;

            if (jumpValue > maxJumpValue)
            {
                jumpValue = maxJumpValue;
            }
        }
        else
        {
            //初期化
            jumpChargeFlag = false;
            jumpValue = 0;
        }
        
    }

    //ジャンプ
    void Jump()
    {
        //jumpvalue調整
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
            //柱フラグオフ
            isPile = false;
            ////コライダーオフ
            GetComponent<BoxCollider>().enabled = false;

            Invoke("ColiiderEnable", 0.2f);

            //transform.position += Vector3.up * 2;

            //柱ジャンプ
            playerRb.AddForce(Vector3.up * jumpPower * 1.5f * jumpValue);
        }
        else
        {
            //通常ジャンプ
            playerRb.AddForce(Vector3.up * jumpPower * jumpValue);
        }
        

        //フラグオフ
        jumpChargeFlag = false;

        //初期化
        jumpValue = 0;
    }

    //何かに当たったら
    private void OnCollisionEnter(Collision collision)
    {
        //地上にいるか判定
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }

        //パワーアップアイテムに当たったら
        if(collision.gameObject.CompareTag("PowerUp"))
        {
            powerUpType = collision.gameObject.GetComponent<PowerUpScript>().type;
            GetComponent<PlayerPowerUseScript>().SetPowerType(powerUpType);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //地上を離れたか判定
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }

    //地面フラグ取得
    public bool GetIsGround() { return isGround; }

    //コライダーイネーブル Invoke用
    private void ColiiderEnable()
    {
        //コライダー設定オン
        GetComponent<BoxCollider>().enabled = true;
    }
    
}
