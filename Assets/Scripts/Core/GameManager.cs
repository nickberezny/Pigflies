using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{


    protected override void Awake()
    {

        base.Awake();
        DontDestroyOnLoad(this);
        LoadMenu();
    }

    public void LoadLevel(string level)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(level);
        ao.completed += OnLevelLoaded;
    }

    public void LoadMenu()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync("MainMenu");
        ao.completed += OnMainMenuLoad;
    }

    void OnLevelLoaded(AsyncOperation ao)
    {
        PlayerManager.Instance.CreatePlayer(new Vector3(0, 0, 0));
        return;
    }

    void OnMainMenuLoad(AsyncOperation ao)
    {
        return;
    }
}
