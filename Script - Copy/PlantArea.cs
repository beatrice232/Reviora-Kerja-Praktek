using UnityEngine;

public class PlantArea : MonoBehaviour
{
    public GameObject sproutPrefab;
    private bool _playerDeket = false;
    private bool _benihDitanam = false;  // sudah ditanam tapi belum tumbuh
    private bool _sudahTumbuh = false;   // sudah tumbuh, tidak bisa ditanam lagi
    private PlantSeed _nanam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerDeket = true;
            _nanam = other.GetComponent<PlantSeed>();
            if (_nanam == null)
                Debug.LogError("PlantSeed tidak ditemukan di Player!");
            else
                Debug.Log("PlantSeed ditemukan: " + _nanam.gameObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerDeket = false;
            _nanam = null;
        }
    }

    void Update()
    {
        if (_playerDeket && Input.GetKeyDown(KeyCode.E) && _nanam != null)
        {
            if (_sudahTumbuh)
            {
                Debug.Log("Sudah ada pohon di sini!");
                return;
            }

            if (_benihDitanam)
            {
                Debug.Log("Benih sudah ditanam, tinggal disemprot!");
                return;
            }

            if (_nanam.UseSeed())
            {
                
                
                _benihDitanam = true;
                Debug.Log("Benih ditanam! Semprot untuk tumbuhkan." + _nanam.seedCount);
            }
            else
            {
                Debug.Log("Tidak punya seed!");
            }
        }
    }

    // Dipanggil oleh Spray.cs
    public bool GrowSeedNow()
    {
        if (_benihDitanam && !_sudahTumbuh)
        {
            _sudahTumbuh = true;
            _benihDitanam = false;

            GameObject sprout = Instantiate(sproutPrefab, transform.position, Quaternion.identity);
            if (sprout.TryGetComponent<SproutSlider>(out SproutSlider ss))
                ss.StartGrowing();
            else
                Debug.LogError("SproutSlider tidak ditemukan di prefab sprout!");

            TreeCounter.Instance.PohonDitanam();

            Debug.Log("Pohon tumbuh!");
            return true;
        }
        else if (!_benihDitanam)
        {
            Debug.Log("Belum ada benih di sini!");
            return false;
        }
        else
        {
            Debug.Log("Pohon sudah tumbuh!");
            return false;
        }
    }

}