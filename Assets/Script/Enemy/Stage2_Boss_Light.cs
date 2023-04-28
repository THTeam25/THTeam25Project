using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Boss_Light : MonoBehaviour
{
    public float duration = 5.0f;  // ���̏����鎞�ԁi�b�j
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
        
    }

    private void Update()
    {
        Intensity = lightComponent.intensity;
        GameObject manager_Stage2RandomMove = GameObject.Find("Manager_Stage2RandomMove");
        Boss_RamdomMove BRM = manager_Stage2RandomMove.GetComponent<Boss_RamdomMove>();
        if (BRM.behavior1Active == true)
        {
            float elapsed = Time.time - startTime;  // �o�ߎ��Ԃ��v�Z
            
            if(countnum == 0)
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
            //    lightComponent.intensity += plusintensity;  // ���̋��x���X�V

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
