using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSoundManager : MonoBehaviour
{
    //�T�E���h
    SoundManagerScript sMS;
    public AudioClip selectSound;
    bool bSound = true;

    // Start is called before the first frame update
    void Start()
    {
        //�T�E���h�}�l�[�W���[�擾
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
