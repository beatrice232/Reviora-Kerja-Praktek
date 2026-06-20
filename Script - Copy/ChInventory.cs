using UnityEngine;
using UnityEngine.EventSystems;

public class ChInventory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float _Click;
    void Start()
    {
        _Click = 1f;
    }
    public void CloseInventory()
    {
        _Click *= -1f;
        transform.localScale = new Vector3(_Click, 1f, 1f);
    }
}
