using UnityEngine;
using UnityEngine.UI;

public class PrefSeed : MonoBehaviour
{
    [SerializeField] private GameObject SeedPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if (TryGetComponent<Button>(out Button btn))
        {
            btn.onClick.AddListener(AmbilSeed);
        }
    }
    private void AmbilSeed()
    {
        PlantSeed playerSeed = FindAnyObjectByType<PlantSeed>();

        if (playerSeed != null)
        {
            playerSeed.AddSeed();

            Debug.Log("Seed ditambah. Total: " + playerSeed.seedCount);

            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("PlantSeed tidak ditemukan!");
        }


    }
}
