using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLifeUIScript : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[10];

    public bool gameOverFlag;
    private int lifePoint = 10;
    private bool Flag;

    private GameObject soundManager;
    [SerializeField]
    private AudioClip clip1;//“G‚É“–‚½‚é‰¹


    void Start()
    {
        soundManager = GameObject.Find("SoundManager");
        gameOverFlag = false;
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
        if(lifePoint <= 0)
        {
            gameOverFlag = true;
        }
    }

}

