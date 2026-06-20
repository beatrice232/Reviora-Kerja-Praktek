using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FadeOut : MonoBehaviour
{
    SpriteRenderer rendPohon;
    private bool sudahMulaiFade = false;

    private void Start()
    {
         rendPohon = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        // cari object kontaminasi lewat tag
        if (sudahMulaiFade) return;
        GameObject[] semuaKontaminasi = GameObject.FindGameObjectsWithTag("Contamination");
        if (semuaKontaminasi.Length == 0)
        {
            sudahMulaiFade = true;
            StartCoroutine(FadeOutPohon());
            Debug.Log("Pohon Mulai hilang ");
        }
        else                                                    
        {
            Debug.Log("Object dengan tag Kontaminasi tidak ditemukan!");
        }
    }

    IEnumerator FadeOutPohon()
    {
        if (rendPohon == null)
        {
            Debug.LogError("SpriteRenderer Pohon tidak ditemukan!");
            yield break;
        }

        // Looping untuk mengurangi Alpha (transparansi) secara halus
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = rendPohon.color;
            c.a = f;
            rendPohon.color = c;

            // Menunggu 0.05 detik sebelum mengurangi alpha berikutnya
            yield return new WaitForSeconds(0.05f);
        }
        Debug.Log("Pohon berhasil menghilang sepenuhnya!");

        Destroy(gameObject);
    }
}

