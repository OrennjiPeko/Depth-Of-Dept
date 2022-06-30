using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasDontDestroy : MonoBehaviour
{


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        
        SceneManager.sceneLoaded -= OnSceneLoaded;

         SceneManager.sceneLoaded += OnSceneLoaded;
        
    }


    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //Destroys canvas on the main menu
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            //Destroy(this.gameObject);
        }

    }
}
