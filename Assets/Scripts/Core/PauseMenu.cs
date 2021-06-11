using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Canvas _pauseMenu;
    public bool _pause { private set; get; }

    private void Start()
    {
        _pause = true;
        TogglePause();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        _pause = !_pause;
        _pauseMenu.enabled = _pause;
        Time.timeScale = _pause ? 0 : 1;
        
    }

    public void LoadMenu()
    {
        GameManager.Instance.LoadMenu();
    }
}
