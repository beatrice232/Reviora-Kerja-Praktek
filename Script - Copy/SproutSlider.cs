using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SproutSlider : MonoBehaviour
{
    public float growTime = 30f;
    public Slider growthSlider;
    public GameObject TreePrefab;
    public GameObject SproutPrefab;
    private GameObject currentActiveObject;
    public float fadeSpeed = 1f;
    public float TreeYOffset = 10f;
    public GameObject Btn_SeedPrefab;
    public Transform CanvasTransform;

    
    public void StartGrowing()
    {
        StopAllCoroutines();
        StartCoroutine(RunSlider());
    }

    private IEnumerator RunSlider()
    {
        if (SproutPrefab != null)
        {
            if (currentActiveObject != null) Destroy(currentActiveObject);
            currentActiveObject = Instantiate(SproutPrefab, transform.position, Quaternion.identity);
        }

        else
        {
            Debug.LogError("prefabSprout belum dimasukkan di Inspector!");
            yield break;
        }

        if (growthSlider != null)
        {
            growthSlider.gameObject.SetActive(true);
            growthSlider.minValue = 0f;
            growthSlider.maxValue = 1f;
            growthSlider.value = 0f;
        }

        float timer = 0f;
        while (timer < growTime)
        {
            timer += Time.deltaTime;
            if (growthSlider != null)
                growthSlider.value = timer / growTime;
            yield return null;
        }

        if (growthSlider != null)
            growthSlider.gameObject.SetActive(false);

        // Hapus sprout
        Destroy(currentActiveObject);

        if (TreePrefab != null)
        {
            Vector3 treePosition = transform.position;
            treePosition.y += TreeYOffset;
            currentActiveObject = Instantiate(TreePrefab,treePosition, Quaternion.identity);


            SpriteRenderer sr;
                if (!currentActiveObject.TryGetComponent<SpriteRenderer>(out sr))
                sr = currentActiveObject.GetComponentInChildren<SpriteRenderer>();

            if (sr == null)
            {
                sr = currentActiveObject.GetComponentInChildren<SpriteRenderer>();
            }

            if (sr != null)
            {
                Color c = sr.color;
                c.a = 0f;
                sr.color = c;

                while (c.a < 1f)
                {
                    c.a += Time.deltaTime * fadeSpeed;
                    sr.color = c;
                    yield return null;
                }

                c.a = 1f;
                sr.color = c;
            }

            Debug.Log("Pohon berhasil muncul!");
        }
        else
        {
            Debug.Log("TreePrefab belum dimasukkan!");
        }

        if (CanvasTransform == null)
        {
            GameObject canvasObj = GameObject.FindWithTag("canvasBtnSeed");
            if (canvasObj != null)
                CanvasTransform = canvasObj.transform;
        }

        if (Btn_SeedPrefab != null && CanvasTransform != null)
        {
            GameObject spawnedButton = Instantiate(Btn_SeedPrefab, CanvasTransform);
            RectTransform buttonRT = spawnedButton.GetComponent<RectTransform>();
            if (buttonRT != null)
            {
                buttonRT.localPosition = Vector3.zero;
                buttonRT.localScale = Vector3.one;
            }

             FollowWorldPos follow = spawnedButton.GetComponent<FollowWorldPos>();
            if (follow != null)
            {
                follow.SetTarget(transform);

            }
            else
            {
                Debug.LogError("error kocag kocagg");
            }
        }
        else
        {
            if (Btn_SeedPrefab == null) Debug.LogError("button");
            if (CanvasTransform != null) Debug.LogError("canvas") ;
        }
    }

}