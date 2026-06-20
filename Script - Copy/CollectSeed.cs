using UnityEngine;

public class Collectseed : MonoBehaviour
{
    public string seedName;
    public Sprite seedSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Seed diambil: " + seedName);
            Destroy(gameObject);
        }
    }
}
