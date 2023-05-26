using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSoundManager : MonoBehaviour
{
    //サウンド
    SoundManagerScript sMS;
    public AudioClip selectSound;
    bool bSound = true;

    // Start is called before the first frame update
    void Start()
    {
        //サウンドマネージャー取得
        sMS = GameObject.Find("SoundManager").GetComponent<SoundManagerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject == EventSystem.current.currentSelectedGameObject)
        {
            if (bSound)
            {
                bSound = false;

                sMS.PlaySe(selectSound);

            }
        }
        else
        {
            bSound = true;
        }
    }
}
