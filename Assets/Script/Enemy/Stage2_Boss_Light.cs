using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Boss_Light : MonoBehaviour
{
    public float duration = 5.0f;  // 光の消える時間（秒）
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
        
    }

    private void Update()
    {
        Intensity = lightComponent.intensity;
        GameObject manager_Stage2RandomMove = GameObject.Find("Manager_Stage2RandomMove");
        Boss_RamdomMove BRM = manager_Stage2RandomMove.GetComponent<Boss_RamdomMove>();
        if (BRM.behavior1Active == true)
        {
            float elapsed = Time.time - startTime;  // 経過時間を計算
            
            if(countnum == 0)
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
                    //lightup = true;
                    //plusintensity = (startIntensity / duration) / 60.0f;
                    BRM.behavior1Active = false;
                    BRM.behavior2Active = true;
                    countnum = 0;
                }
            }
            //else
            //{
            //    //plusintensity = ((startIntensity - lightComponent.intensity) / duration) / 60.0f;
            //    lightComponent.intensity += plusintensity;  // 光の強度を更新

            //    if (lightComponent.intensity >= startIntensity)
            //    {
            //        BRM.behavior1Active = false;
            //        BRM.behavior2Active = true;
            //        countnum = 0;
            //    }
            //}
        }
    }
}
