using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private bool isEntering = false;
    [SerializeField] private GameObject TextInteract;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            isEntering = true;
            TextInteract.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isEntering = false;
            TextInteract.SetActive(false);
        }
    }

}
