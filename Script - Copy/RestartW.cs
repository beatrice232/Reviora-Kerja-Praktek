using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartW : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }

    public void No()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
