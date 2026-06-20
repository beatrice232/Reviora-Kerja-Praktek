using System.Collections;
using UnityEngine;

public class ButtonChecker : MonoBehaviour
{
    public static ButtonChecker Instance;
    public static System.Action onAllButtonDestroyed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        onAllButtonDestroyed = null;
    }

    public void CekSetelahDestroy()
    {
        StartCoroutine(Cek());
    }

    private IEnumerator Cek()
    {
        yield return null;
        ButtonSeed[] sisa = FindObjectsByType<ButtonSeed>(FindObjectsInactive.Exclude);
        if (sisa.Length == 0)
        {
            Debug.Log("Invoke event");
            onAllButtonDestroyed?.Invoke();
        }
            
    }
    
}
