using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1_Boss_HealthManager : MonoBehaviour
{
    public int maxHealth = 3;   // �ő�HP
    public int currentHealth;   // ���݂�HP
    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;
    [SerializeField]
    private int num = 5;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int v)
    {
        currentHealth--;

        // HP��0�ɂȂ�����Q�[���N���A�V�[���Ɉڍs����
        if (currentHealth <= 0)
        {
            HP1.SetActive(false);
            num--;
            if (num <= 0)
            {

                SceneManager.LoadScene("GameClear");

            }

        }

        // HP�����邽�тɃQ�[���I�u�W�F�N�g��������ł���
        if (currentHealth == 2) HP3.SetActive(false);
        if (currentHealth == 1) HP2.SetActive(false);
    }
}
