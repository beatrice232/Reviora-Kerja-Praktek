using UnityEngine;

public class PlantTrigger : MonoBehaviour
{
    [SerializeField] private bool isEntering = false;
    [SerializeField] private GameObject TextInteract;

    private void Update()
    {
        // Fitur Tambahan (Opsional): Jika pemain sudah di dalam area, tapi kontaminasi 
        // baru habis saat pemain sedang berdiri di sana, teks otomatis langsung menyala.
        if (isEntering && TextInteract != null)
        {
            int contaminationCount = GameObject.FindGameObjectsWithTag("ContaminationFinalboss").Length;

            if (contaminationCount == 0 && !TextInteract.activeSelf)
            {
                TextInteract.SetActive(true);
            }
            else if (contaminationCount > 0 && TextInteract.activeSelf)
            {
                TextInteract.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isEntering = true;

            // KUNCI UTAMA: Hitung sisa kontaminasi saat pemain masuk area
            int contaminationCount = GameObject.FindGameObjectsWithTag("Contamination").Length;

            // Teks HANYA akan menyala jika kontaminasi sudah HABIS (sama dengan 0)
            if (contaminationCount == 0)
            {
                if (TextInteract != null)
                {
                    TextInteract.SetActive(true);
                }
            }
            else
            {
                Debug.Log("Pemain masuk area, tapi teks dikunci karena kontaminasi belum habis!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isEntering = false;

            if (TextInteract != null)
            {
                TextInteract.SetActive(false);
            }
        }
    }
}