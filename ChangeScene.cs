using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //Setup
    public string NextScene;

    //Changing The Scene
    public void ChangeTheScene()
    {
        //If SceneAsset Available
        if (!string.IsNullOrEmpty(NextScene))
        {
            SceneManager.LoadScene(NextScene);
        }
        else
        {
            Debug.LogWarning("NextScene is not assigned!");
        }
    }
}
