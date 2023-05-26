using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public float duration = 1.0f;  // 光の消える時間（秒）
    public float startIntensity = 1.0f;  // 光の最初の強度
    public Light lightComponent;
    public float plusintensity;
    public float Intensity;

    [SerializeField] private float waitTime = 3.0f;  //暗闇待機時間

    private float startTime;  // 減衰開始時間
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
            float elapsed = Time.time - startTime;  // 経過時間を計算

            if (countnum == 0)
            {
                startTime = Time.time;  // 減衰開始時間を現在の時間に設定
                Intensity = lightComponent.intensity;
                lightup = false;
                minusintensity = ((startIntensity / duration) / 60.0f);
                countnum = 1;
            }


            if (!lightup)
            {
                //float ratio = 1.0f - Mathf.Clamp01(elapsed / duration);  // 減衰率を計算
                //lightComponent.intensity = startIntensity * ratio;  // 光の強度を更新


                lightComponent.intensity -= minusintensity;

                if (lightComponent.intensity == 0 && elapsed >= (duration + waitTime))
                {
                    SceneManager.LoadScene("GameOver");//GameOverシーンに移行
                    countnum = 0;
                }
            }
        }
    }
}
