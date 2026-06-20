using UnityEngine;
using UnityEngine.UI;

public class ButtonSeed : MonoBehaviour
{
    [SerializeField] private GameObject SeedPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
        if (rt != null)
        {
            rt.sizeDelta = new Vector2(100, 100);
            transform.localScale = Vector3.one;
        }

        if (TryGetComponent<Button>(out Button btn))
        {
            btn.onClick.AddListener(AmbilSeed);
        }
        else
        {
            Debug.Log("Skrip ini harus dipasang di GameObject yang memiliki komponen Button!");
        }

    }
    private void AmbilSeed()
    {
        PlantSeed playerseed = FindAnyObjectByType<PlantSeed>();

        if (playerseed != null)
        {
            playerseed.AddSeed();
            Destroy(gameObject);
        }

    }
}