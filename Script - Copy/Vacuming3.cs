using UnityEngine;

public class Vacuming3 : MonoBehaviour
{
    [SerializeField] private float CurrentTimer = 100;
    [SerializeField] private GameObject TextInteract;
    [SerializeField] private bool isEntering = false;
    [SerializeField] private GameObject _ContaminateSprite;
    [SerializeField] private GameObject _ContaminateSprite2;
    [SerializeField] private GameObject _ContaminateSprite3;
    [SerializeField] private float _sizeReduction = 0.25f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        OnVacuum();
    }

    public void OnVacuum()
    {
        if (!isEntering) return;
        if (Input.GetKey(KeyCode.E))
        {
            if (CurrentTimer > 0)
            {
                CurrentTimer -= Time.deltaTime;
                _ContaminateSprite.transform.localScale = _ContaminateSprite.transform.localScale - (_ContaminateSprite.transform.localScale * _sizeReduction);
                _ContaminateSprite2.transform.localScale = _ContaminateSprite2.transform.localScale - (_ContaminateSprite2.transform.localScale * _sizeReduction);
                _ContaminateSprite3.transform.localScale = _ContaminateSprite2.transform.localScale - (_ContaminateSprite3.transform.localScale * _sizeReduction);
            }
            else
            {
           
                Destroy(_ContaminateSprite);
                Destroy(_ContaminateSprite2);
                Destroy(_ContaminateSprite3);
            }

        }
    }

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
