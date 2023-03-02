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
    //ジャンプにかけ合わせる数値 1 = 100%, 0 = 0%
    public float jumpRatio = 0;
    //ジャンプ入力値
    public float jumpValue = 0.0f;
    //最大ジャンプ入力値
    public float maxJumpValue = 180.0f;
    //空中移動倍率
    public float moveRatio = 10.0f;

    //ヒット下杭
    public GameObject hitPile;
    //ヒット銃オブジェクト
    private GameObject hitGun = null;

    //杭ジャンプ方向
    public Vector3 pileJumpVector;

    //デフォルトスケール
    private float defaultScaleY;
    //通常ジャンプの強さ
    private float nomalJumpinput;
    //最大何倍まで伸びるか
    public float maxExtend = 3.0f;
    //どれくらい伸びたか
    private float extendValue = 0.0f;

    //コントローラーの入力情報
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
    //移動フラグ
    public bool isMove = true;
    //空中移動フラグ
    public bool flyMove = false;

    //リジットボディ
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネント取得
        playerRb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        //スケール取得
        defaultScaleY = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        //移動
        if (isMove)
        {
            Move();
        }


        //柱か地上にいなければフラグオフ
        if (!(isGround || isSeize))
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

    public void OnMove(InputAction.CallbackContext context)
    {
        //左スティック入力
        leftX = context.ReadValue<Vector2>().x;


    }

    //移動
    void Move()
    {
        if(isGround)
        {
            //地上時
            transform.Translate(new Vector3(0, 0, 1) * speed * leftX * Time.deltaTime, Space.World);
        }
        else
        {
            //空中時
            transform.Translate(new Vector3(0, 0, 1) * speed * leftX * Time.deltaTime * moveRatio, Space.World);

            if(!flyMove && leftX != 0)
            {
                //空中移動フラグオン
                flyMove = true;

                //左右の物理的速度を一度0にする
                Vector3 temp = playerRb.velocity;
                temp.z = 0;
                playerRb.velocity = temp;
            }
        }
        


    }

    //ジャンプボタンが話されたられたら
    public void OnJump(InputAction.CallbackContext context)
    {
        //地面か柱にいなければジャンプする
        if (context.performed && (isGround || isSeize) && isMove)
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
        if (isGround || isSeize)
        {
            //柱ジャンプベクトル取得
            pileJumpVector.y = playerInput.actions["JumpCharge"].ReadValue<Vector2>().y;
            pileJumpVector.z = playerInput.actions["JumpCharge"].ReadValue<Vector2>().x;
            //柱ジャンプベクトル反転
            pileJumpVector *= -1;

            //掴んでいたら入力に沿ってPlayer伸ばす
            if (isSeize && hitPile)
            {
                Extend();
            }

            //ジャンプ割合入力値代入
            if(jumpRatio <= playerInput.actions["JumpCharge"].ReadValue<Vector2>().magnitude)
            {
                jumpRatio = playerInput.actions["JumpCharge"].ReadValue<Vector2>().magnitude;
            }
            
        }
        else
        {
            jumpValue = 0.0f;
        }


    }

    //ジャンプチャージボタンが押されたら
    public void OnChargeJump(InputAction.CallbackContext context)
    {
        if (context.started && isMove)
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

        if (isSeize)
        {
            //柱フラグオフ
            isPile = false;
            //掴みフラグオフ
            isSeize = false;

            //柱ジャンプ
            playerRb.AddForce(pileJumpVector * (jumpPower * jumpRatio) * 1.5f);

            //伸ばしを元に戻す
            FinishExtend();

        }
        else
        {

            if (jumpRatio < 0)
            {
                jumpRatio *= -1;
            }


            //通常ジャンプ
            playerRb.AddForce(Vector3.up * jumpPower * jumpRatio);

            //地上フラグオフ
            isGround = false;
        }


        //フラグオフ
        jumpChargeFlag = false;
        //初期化
        jumpValue = 0;
        jumpRatio = 0;
        flyMove = false;
    }

    //何かに当たったら
    private void OnCollisionEnter(Collision collision)
    {
        //地上にいるか判定
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;

            playerRb.velocity = Vector3.zero;
        }

        //パワーアップアイテムに当たったら
        if (collision.gameObject.CompareTag("PowerUp"))
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



    //掴む
    public void OnSeize(InputAction.CallbackContext context)
    {
        //ボタンが押されたら
        if (context.started && isMove)
        {
            //柱にトリガーしていて掴んでいなければ掴む
            if (isPile && !isSeize)
            {
                isSeize = true;
            }

        }

    }

    //Player伸ばす
    private void Extend()
    {
        //代入するyスケール計算
        extendValue = playerInput.actions["JumpCharge"].ReadValue<Vector2>().magnitude * maxExtend;
        extendValue += 1;
        Vector3 tempScal = transform.localScale;
        tempScal.y = defaultScaleY * extendValue;

        //スケール代入
        transform.localScale = tempScal;

        //入力に合わせてPlayerを回転
        Vector3 tempRot = new Vector3(0, 90, 0);
        float xinput = playerInput.actions["JumpCharge"].ReadValue<Vector2>().x;
        float yinput = playerInput.actions["JumpCharge"].ReadValue<Vector2>().y;

        tempRot.z = Mathf.Atan2(xinput, yinput) * Mathf.Rad2Deg;

        transform.RotateAround(hitPile.transform.position, new Vector3(0, 0, 1), tempRot.z);

        transform.rotation = Quaternion.Euler(tempRot);
    }

    //Player伸ばす終了
    private void FinishExtend()
    {
        Vector3 tempscal = transform.localScale;
        tempscal.y = defaultScaleY;

        //Playerのスケールを元に戻す
        transform.localScale = tempscal;
        //かけ合わせるyスケールを1に戻す
        extendValue = 1;

        //角度を元に戻す
        Vector3 tempRot = transform.rotation.eulerAngles;
        tempRot.z = 0;
        transform.rotation = Quaternion.Euler(tempRot);

    }

    //どれくらい伸びたか返す
    public float GetExtendValue() { return extendValue; }

    //移動フラグ設定
    public void SetMove(bool b)
    {
        isMove = b;
    }

    //発射
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed && hitGun)
        {
            hitGun.GetComponent<GomGunScript>().Fire();
        }
    }

    //ヒット下銃設定
    public void SetHitGun(GameObject go)
    {
        hitGun = go;
    }

}