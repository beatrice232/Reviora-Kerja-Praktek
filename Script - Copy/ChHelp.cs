
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChHelp : MonoBehaviour
{
    public UnityEngine.UI.Image image;
    public List<Sprite> spriteChoices;
    private int Counter;
    private int CurrentSprite = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    public void NextSprite()
    {
        Counter++;
        print(Counter);
        if (Counter == 1)
        {
            CurrentSprite++;
            Counter = 0;
            if (CurrentSprite >= spriteChoices.Count)
            {
                CurrentSprite = 0;
            }
            image.sprite = spriteChoices[CurrentSprite];
        }
    }
}
