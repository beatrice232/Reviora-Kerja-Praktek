using System;
using UnityEngine;

public class RestartPanel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Restartpanel;

    // Update is called once per frame

    public void Pause()
    {
        Restartpanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        RestartPanel.SetActive(false);
        Time.timeScale = 1;
    }

    private static void SetActive(bool v)
    {
        throw new NotImplementedException();
    }
}
