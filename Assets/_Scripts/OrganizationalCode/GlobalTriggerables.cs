using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTriggerables : Singleton<GlobalTriggerables> {

    protected GlobalTriggerables() { }

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void PauseUnpause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public Canvas menu;

    public void OpenCloseMenu()
    {
        if (!menu.gameObject.activeSelf)
        {
            menu.gameObject.SetActive(true);
        }
        else
        {
            menu.gameObject.SetActive(false);
        }
    }
}
