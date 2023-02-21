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

    //杭ジャンプ方向
    public Vector3 pileJumpVector;
    public float nomalJumpinput;
    //PlayerInput
    public PlayerInput playerInput;

    //パワーアップタイプ
    public PowerUpScript.PowerUp powerUpType;

    //ジャンプチャージフラグ
    public bool jumpChargeFlag = false;
    //地上フラグ
    public bool isGround;
    //柱にトリガーしているか
    public bool isPile = false;
    //柱をつかんでいるか
    public bool isSeize = false;

    //リジットボディ
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
        //移動
        Move();


        //柱か地上にいなければフラグオフ
        if(!(isGround || isSeize))
        {
            jumpChargeFlag = false;
        }
        
        if (jumpChargeFlag)
        {
            //ジャンプため
            ChargeJump();
        }
        else 
        {
            jumpValue = 0;
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
        
        transform.Translate(new Vector3(0,0,1) * speed * leftX * Time.deltaTime,Space.World);

        transform.Rotate(new Vector3(1,0,0) * leftX, Space.World);
    }

    //ジャンプボタンが話されたられたら
    public void OnJump(InputAction.CallbackContext context)
    {

       
 
        //地面か柱にいなければジャンプする
        if (context.performed && (isGround || isSeize))
        {
            

            //ジャンプ
            Jump();

            jumpChargeFlag = false;
            jumpValue = 0;
        }
    }

    //ジャンプため
    public void ChargeJump()
    {
        //地上にいる間だけ加算
        if(isGround || isSeize)
        {
            //柱ジャンプベクトル取得
            pileJumpVector.y = playerInput.actions["JumpCharge"].ReadValue<Vector2>().y;
            pileJumpVector.z = playerInput.actions["JumpCharge"].ReadValue<Vector2>().x;
            //柱ジャンプベクトル反転
            pileJumpVector *= -1;
            //通常ジャンプ入力値
            nomalJumpinput = playerInput.actions["JumpCharge"].ReadValue<Vector2>().magnitude;
        }
        else
        {
            jumpValue = 0.0f;
        }

        
    }
    
    //ジャンプチャージボタンが押されたら
    public void OnChargeJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //地上か柱にいる間だけ
            if (isGround || isSeize)
            {
                //フラグオン
                jumpChargeFlag = true;


            }
            else
            {
                //フラグオフ
                jumpChargeFlag = false;

            }

            
        }

    }

    //ジャンプ
    void Jump()
    {
        //ベロシティを0にする
        GetComponent<Rigidbody>().velocity = Vector3.zero;
       
        if (isSeize)
        {
            //柱フラグオフ
            isPile = false;
            //掴みフラグオフ
            isSeize = false;

            ////コライダーオフ
            GetComponent<SphereCollider>().enabled = false;

            Invoke("ColiiderEnable", 0.2f);

            //transform.position += Vector3.up * 2;

            //柱ジャンプ
            playerRb.AddForce(pileJumpVector * (jumpPower * pileJumpVector.magnitude) * 1.5f);

            //ヒットした柱をnullにする
            hitPile = null;

            

        }
        else
        {
            
            if(nomalJumpinput <0)
            {
                nomalJumpinput *= -1;
            }


            //通常ジャンプ
            playerRb.AddForce(Vector3.up * jumpPower * nomalJumpinput);

            //地上フラグオフ
            isGround = false;
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
        GetComponent<SphereCollider>().enabled = true;
    }

    //掴む
    public void OnSeize(InputAction.CallbackContext context)
    {
        //ボタンが押されたら
        if(context.started)
        {
            //柱にトリガーしていて掴んでいなければ掴む
            if (isPile && !isSeize)
            {
                isSeize = true;
            }
            //掴んでいれば放す
            else if (isSeize)
            {
                isSeize = false;
            }
        }
        
    }
    
}
