using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("level1");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void X()
    {
        SceneManager.LoadScene("mainmenu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}