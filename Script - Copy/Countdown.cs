using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField]float remainingTime;
    private bool sudahHabis = false;
    public GameObject Restartwaktupanel;
   
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0 && !sudahHabis)
        {
            remainingTime = 0;
            timerText.color = Color.red;
            sudahHabis = true;
            Time.timeScale = 0f;
            
            Restartwaktupanel.SetActive(true);
        }
   
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private System.Collections.IEnumerator Tunggu()
    {
        yield return new WaitForSeconds(0.5f);

    }
}
