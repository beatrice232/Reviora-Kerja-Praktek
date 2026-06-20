using UnityEngine;

public class Seeds : MonoBehaviour
{
    public GameObject seedPrefab;
    public int maxSeeds = 5;
    private int currentSeeds = 0;
    public float placeDistance = 2f;
    private bool nearTree = false;

    void Update()
    {
        // Ambil seed dari pohon
        if (Input.GetKeyDown(KeyCode.F) && nearTree)
        {
            TakeSeed();
        }

        // Tanam seed
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlantSeed();
        }
    }

    void TakeSeed()
    {
        // Inventory penuh
        if (currentSeeds >= maxSeeds)
        {
            Debug.Log("Inventory seed penuh!");
            return;
        }

        currentSeeds++;

        Debug.Log("Seed diambil dari pohon!");
        Debug.Log("Total Seed: " + currentSeeds);
    }

    void PlantSeed()
    {
        // Tidak punya seed
        if (currentSeeds <= 0)
        {
            Debug.Log("Tidak punya seed!");
            return;
        }

        // Posisi seed di depan player
        Vector3 placePosition =
            transform.position + transform.forward * placeDistance;

        // Spawn seed
        GameObject newSeed = Instantiate(
            seedPrefab,
            placePosition,
            Quaternion.identity
        );

       

        // Kurangi inventory
        currentSeeds--;

        Debug.Log("Seed ditanam!");
        Debug.Log("Sisa Seed: " + currentSeeds);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SeedTree"))
        {
            nearTree = true;

            Debug.Log("Dekat pohon seed");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("SeedTree"))
        {
            return;
        }
        nearTree = false;

        Debug.Log("Menjauh dari pohon");
    }
 }

