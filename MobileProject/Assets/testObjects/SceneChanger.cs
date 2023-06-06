using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour 
{ 
    public void ChangeScene(string sceneName) 
    { 
        SceneManager.LoadScene(sceneName); 
    } 
    public void Exit() 
    { 
        Application.Quit(); 
    } 

    public void CloseOpenPanels(GameObject obj)
    {
        obj.SetActive(true) ;
        Debug.Log(transform.parent.gameObject);
    }
}
