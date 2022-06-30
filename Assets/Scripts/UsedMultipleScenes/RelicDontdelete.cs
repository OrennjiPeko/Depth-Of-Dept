using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RelicDontdelete : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
          Destroy(this.gameObject); 
        
    }
}
