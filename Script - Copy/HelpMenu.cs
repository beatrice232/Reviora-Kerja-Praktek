using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public GameObject HelpPanel;
    // Update is called once per frame
   

    public void pause()
    {
        HelpPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        HelpPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
