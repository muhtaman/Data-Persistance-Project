using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{

    public GameObject InputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    public void Exit()
    {
        SaveData.Instance.SaveScore();
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();

        #endif
    }

    public void UpdateUsername() {
        String input = InputField.GetComponent<Text>().text;
        SaveData.Instance.username = input;
        Debug.Log(input);
    }
}
