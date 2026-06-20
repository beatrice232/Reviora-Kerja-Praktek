
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GantigambarAlex : MonoBehaviour
{
    public UnityEngine.UI.Image image;
    public GameObject introPanel;
    public List<Sprite> spriteChoices;
    private int CurrentSprite = 0;

    private void Start()
    {
        Time.timeScale = 0f;

        if (introPanel != null)
        {
            introPanel.SetActive(true);
        }
            

        if (spriteChoices != null && spriteChoices.Count > 0 && image != null)
        {
            image.sprite = spriteChoices[0];
            CurrentSprite = 0;
        }

        else
        {
            Debug.LogError(" Image belum!");
        }
    }
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            NextSprite();
        }
    }
    public void NextSprite()
    {
        CurrentSprite++;

        // 4. Jika indeks gambar sudah melewati batas akhir jumlah total gambar di list
        if (CurrentSprite >= spriteChoices.Count)
        {
            EndIntroAndStartGame();
            return;
        }

        
        if (image != null)
        {
            image.sprite = spriteChoices[CurrentSprite];
            Debug.Log("Maju ke gambar indeks: " + CurrentSprite);
        }
    }

    private void EndIntroAndStartGame()
    {
        Debug.Log("Gambar habis! Menutup intro dan memulai gameplay.");

       
        if (introPanel != null)
        {
            introPanel.SetActive(false);
        }

       
        Time.timeScale = 1f;
    }
}

