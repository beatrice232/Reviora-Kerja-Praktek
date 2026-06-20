using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Image SoundON;
    [SerializeField] Image SoundOFF;
    private bool muted = false;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButton();
        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateButton();
    }

    private void UpdateButton()
    {
        if (muted == false)
        {
            SoundON.enabled = true;
            SoundOFF.enabled = false;
        }
        else
        {
            SoundON.enabled = false;
            SoundOFF.enabled = true;

        }
        if (muted == false)
        {

        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}

