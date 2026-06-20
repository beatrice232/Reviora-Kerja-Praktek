using UnityEngine;

public class QuitMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject QuitPanel;

    // Update is called once per frame

    public void Continue()
    {
        QuitPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


