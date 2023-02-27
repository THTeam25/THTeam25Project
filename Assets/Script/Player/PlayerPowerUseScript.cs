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

    //PowerUp入力値
    public Vector2 powerInput;

    //パワーアップ使用フラグ
    public bool powerUpFlag = false;
    //タイヤで移動中フラグ
    public bool tireMoveFlag = false;
    
    //playerのパワーアップタイプ
    private PowerUpScript.PowerUp powerUpType = PowerUpScript.PowerUp.None;

    //タイヤ進行方向
    public float tireVector = 0.0f;
    //PowerUp値
    public float powerUpValue = 0.0f;
    //最大PowerUp値
    public float powerUpMaxValue = 180.0f;
    //タイヤパワー
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
        //特殊能力使用
        PowerUse();
    }

    //パワー使用
    private void PowerUse()
    {


        ////パワー使用中じゃなければ返す
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
            //パワー使用中フラグオン
            powerUpFlag = true;
        }



        //input取得
        powerInput = context.ReadValue<Vector2>();


    }

    //タイヤ使用ボタンがリリースしたら
    public void RightOnTireUse(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            tireVector = -1;


            //タイヤ使用
            UseTire();
        }
    }
    public void LeftOnTireUse(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            tireVector = 1;


            //タイヤ使用
            UseTire();
        }
    }



    //タイヤ能力溜める
    private void TireCharge()
    {


        if (pS.GetIsGround() && powerUpFlag)
        {
            //加算
            powerUpValue++;

            //値調整
            if (powerUpValue > powerUpMaxValue)
            {
                powerUpValue = powerUpMaxValue;
            }

        }

    }

    //タイヤ能力使用
    private void UseTire()
    {
        //powerUpvalue調整
        powerUpValue /= powerUpMaxValue;

        //飛ばす
        player.GetComponent<Rigidbody>().AddForce(player.transform.forward * powerUpValue * tirePower * tireVector);


        powerUpFlag = false;
        //初期化
        powerUpValue = 0.0f;

        Invoke("SetTireMoveFlagFalse", 5.0f);
    }

    //パワーアップフラグをfalseにする
    private void SetTireMoveFlagFalse()
    {
        tireMoveFlag = false;

    }

    //タイプを設定
    public void SetPowerType(PowerUpScript.PowerUp t)
    {
        powerUpType = t;
    }
}
