using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    //遷移先のシーン
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

    //シーン切り替え
    public void Change()
    {
        //ロード後のシーン
        loadAfterScene = nextScene;
        SceneManager.LoadScene("Load");
    }
}
