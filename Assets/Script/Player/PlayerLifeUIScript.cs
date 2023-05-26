using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLifeUIScript : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[10];
    private int lifePoint = 10;
    private bool Flag;

    [SerializeField]
    private GameObject soundManager;
    [SerializeField]
    AudioClip clip1;//敵に当たる音


    void Start()
    {
        soundManager = GameObject.Find("SoundManager");
    }

    void Update()
    {
        GameObject NH;
        PlayerLifeScript PLS;

        NH = GameObject.Find("Player");
        PLS = NH.GetComponent<PlayerLifeScript>();


        if (lifePoint > PLS.life)
        {
            Flag = true;
        }

        if(Flag)
        {
            lifeArray[lifePoint - 1].SetActive(false);
            lifePoint--;
            soundManager.GetComponent<SoundManagerScript>().PlaySe(clip1);
            Flag = false;
        }
    }

}

