using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_HealthManager : MonoBehaviour
{
    public int maxHealth = 3;   // �ő�HP
    public static int currentHealth;   // ���݂�HP
    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;

    private GameObject chara;

    public bool takedamage = false;

    Animator animator;


    void Start()
    {
        currentHealth = maxHealth;
        chara = GameObject.Find("chara2");
        animator = chara.GetComponent<Animator>();
        takedamage = false;

    }

    void Update()
    {

        // HP��0�ɂȂ����玟�̃V�[���Ɉڍs����
        if (currentHealth <= 0)
        {
            HP1.SetActive(false);

            GetComponent<ChangeScene>().Change();
            currentHealth = maxHealth;
        }
    }
    public void TakeDamage(int val)
    {
        animator.SetTrigger("IsReceiveDamage");
        currentHealth -= val;

        // HP�����邽�тɃQ�[���I�u�W�F�N�g��������ł���
        if (currentHealth == 2) HP3.SetActive(false);
        if (currentHealth == 1) HP2.SetActive(false);



        if (currentHealth <= 0)
        {
            HP1.SetActive(false);
            Death();
        }
        

    }
    void Death()
    {


        GetComponent<ChangeScene>().Change();
        currentHealth = maxHealth;
    }

}
