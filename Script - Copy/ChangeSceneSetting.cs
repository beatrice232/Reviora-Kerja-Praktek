using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneSetting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void X()
    {
        SceneManager.LoadScene("Mainmenu");
    }
}
