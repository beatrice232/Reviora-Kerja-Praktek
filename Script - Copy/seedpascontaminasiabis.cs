using UnityEngine;

public class PohonSeed : MonoBehaviour
{
    [SerializeField] private GameObject _SeedPrefab;

    void Start()
    {
        Instantiate(_SeedPrefab, transform.position + new Vector3(50f, -50f, 0), Quaternion.identity);
    }
}