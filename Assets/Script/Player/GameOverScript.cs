using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public float duration = 1.0f;  // ���̏����鎞�ԁi�b�j
    public float startIntensity = 1.0f;  // ���̍ŏ��̋��x
    public Light lightComponent;
    public float plusintensity;
    public float Intensity;

    [SerializeField] private float waitTime = 3.0f;  //�Èőҋ@����

    private float startTime;  // �����J�n����
    private bool lightup;
    private float minusintensity;
    private int countnum = 0;

    private void Start()
    {
        countnum = 0;
    }

    private void Update()
    {
        Intensity = lightComponent.intensity;
        GameObject player = GameObject.Find("Player");
        PlayerLifeUIScript PUI = player.GetComponent<PlayerLifeUIScript>();
        if (PUI.gameOverFlag == true)
        {
            float elapsed = Time.time - startTime;  // �o�ߎ��Ԃ��v�Z

            if (countnum == 0)
            {
                startTime = Time.time;  // �����J�n���Ԃ����݂̎��Ԃɐݒ�
                Intensity = lightComponent.intensity;
                lightup = false;
                minusintensity = ((startIntensity / duration) / 60.0f);
                countnum = 1;
            }


            if (!lightup)
            {
                //float ratio = 1.0f - Mathf.Clamp01(elapsed / duration);  // ���������v�Z
                //lightComponent.intensity = startIntensity * ratio;  // ���̋��x���X�V


                lightComponent.intensity -= minusintensity;

                if (lightComponent.intensity == 0 && elapsed >= (duration + waitTime))
                {
                    SceneManager.LoadScene("GameOver");//GameOver�V�[���Ɉڍs
                    countnum = 0;
                }
            }
        }
    }
}
