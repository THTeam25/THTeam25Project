using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    //�J�ڐ�̃V�[��
    public string nextScene;

    public static string loadAfterScene;
    // Start is called before the first frame update
    void Start()
    {
        
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
