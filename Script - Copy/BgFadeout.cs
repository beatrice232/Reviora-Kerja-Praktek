using UnityEngine;
using System.Collections;
public class BgFadeout : MonoBehaviour
{
    public float fadeSpeed = 2.5f;
    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        ButtonChecker.onAllButtonDestroyed += FadeOut;
    }

    // Update is called once per frame
    private void OnDestroy ()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void FadeOut()
    {
        StartCoroutine(DoFadeOut());
        Debug.Log("FadeOut dipanggil");
    }

    private IEnumerator DoFadeOut()
    {
        Color c = sr.color;
        while (c.a > 0f)
        {
            c.a -= Time.deltaTime * fadeSpeed;
            sr.color = c;
            yield return null;
        }
        c.a = 0f;
        sr.color = c;
        gameObject.SetActive(false);
    }
}
