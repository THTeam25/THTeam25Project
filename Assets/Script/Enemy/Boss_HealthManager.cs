using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_HealthManager : MonoBehaviour
{
    public int maxHealth = 3;   // 最大HP
    public int currentHealth;   // 現在のHP
    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;

    private GameObject chara;
    Animator animator;


    void Start()
    {
        currentHealth = maxHealth;
        chara = GameObject.Find("chara2");
        animator = chara.GetComponent<Animator>();
    }

    public void TakeDamage(int v)
    {
        currentHealth--;

        // HPが0になったらゲームクリアシーンに移行する
        if (currentHealth <= 0)
        {
            HP1.SetActive(false);


            SceneManager.LoadScene("GameClear");



        }

        // HPが減るたびにゲームオブジェクトを一つずつ消滅する
        if (currentHealth == 2) HP3.SetActive(false);
        if (currentHealth == 1) HP2.SetActive(false);
        //アニメーターコントローラー設定
        animator.SetTrigger("IsReceiveDamage");
    }

}
