using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChangeScene : MonoBehaviour
{

    //�J�ڐ�̃V�[��
    public string nextScene;

    //���Ԍo�߂ŃV�[���J�ڂ���ꍇ
    public bool bTimeFlag;

    public static string loadAfterScene;

 
    // Start is called before the first frame update
    void Start()
    {
        

        if (bTimeFlag)
        {
            Invoke("Change", 3.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {

        

       
    }

    //�V�[���؂�ւ�
    public void Change()
    {
        //���[�h��̃V�[��
        loadAfterScene = nextScene;
        SceneManager.LoadScene("Load");
    }
}
