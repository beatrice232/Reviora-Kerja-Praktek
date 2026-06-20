using UnityEngine;

public class DestroyFinal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject objekVacuum;

    void Update()
    {
        // Cari semua objek yang memiliki tag "Contamination"
        GameObject[] sisaKontaminasi = GameObject.FindGameObjectsWithTag("ContaminationFinalboss");

        // Jika array kosong (artinya semua kontaminasi SUDAH HABIS)
        if (sisaKontaminasi.Length == 0)
        {
            Debug.Log("Semua kontaminasi habis! Objek vacuum otomatis dihancurkan.");

            if (objekVacuum != null)
            {
                Destroy(objekVacuum); // Hancurkan objek vacuum dari Hierarchy
            }

            // Hancurkan juga skrip pengawas ini dari Hierarchy agar tidak membebani memori
            Destroy(gameObject);
        }
    }
}