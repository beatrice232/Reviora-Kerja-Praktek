using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    // Update is called once per frame
 

    public void pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
