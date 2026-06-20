using UnityEngine;
using TMPro;

public class InventoryController : MonoBehaviour
{
    public PlantSeed playerSeed;
    public TMP_Text seedText;

    private void Start()
    {
        playerSeed = FindAnyObjectByType<PlantSeed>();
    }

    private void Update()
    {
        if(playerSeed != null)
        {
            seedText.text = playerSeed.seedCount.ToString();
        }
    }
}