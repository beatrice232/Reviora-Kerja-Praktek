using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public GameObject Inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    public void pause()
    {
        Inventory.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Inventory.SetActive(false);
        Time.timeScale = 1;
    }
}
