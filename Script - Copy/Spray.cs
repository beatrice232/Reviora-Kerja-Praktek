using UnityEngine;

public class Spray : MonoBehaviour
{
    public GameObject sprayParticlePrefab;
    public int sprayCount = 5;

    private PlantArea _nearbyPlant = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (_nearbyPlant == null)
            {
                Debug.Log("Tidak ada area tanam di dekat sini!");
                return;
            }

            bool berhasil = _nearbyPlant.GrowSeedNow();
            if (berhasil)
            {
                sprayCount--;
                SpawnParticle();
                Debug.Log("Spray tersisa: " + sprayCount);
            }
        }
    }

    private void SpawnParticle()
    {
        if (sprayParticlePrefab != null)
        {
            GameObject particle = Instantiate(sprayParticlePrefab, transform.position, Quaternion.identity);
            Destroy(particle, 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlantArea plant = collision.GetComponent<PlantArea>();
        if (plant != null)
        {
            _nearbyPlant = plant;
            Debug.Log("Dekat plant area!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlantArea plant = collision.GetComponent<PlantArea>();
        if (plant != null)
        {
            _nearbyPlant = null;
            Debug.Log("Keluar dari plant area!");
        }
    }
}