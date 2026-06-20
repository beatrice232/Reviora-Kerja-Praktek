using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SproutProgres : MonoBehaviour
{
    public GameObject _TreePrefab;
    public float fadeSpeed = 1f;

    public void SpawnBigTree()
    {
        if (_TreePrefab != null)
        {
            GameObject bigTree = Instantiate(_TreePrefab, transform.position, Quaternion.identity, transform.parent);
            SpriteRenderer treeSR = bigTree.GetComponentInChildren<SpriteRenderer>();

            if (treeSR != null)
            {
                StartCoroutine(FadeInAndDestroySprout(treeSR));
            }
            else
            {
                ActivateTreeCollider(bigTree);
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.LogError("Error: Prefab pohon besar belum dimasukkan di Inspector!");
            Destroy(gameObject);
        }
    }

    private IEnumerator FadeInAndDestroySprout(SpriteRenderer targetSprite)
    {
        Color c = targetSprite.color;
        c.a = 0f; 
        targetSprite.color = c;

        if (targetSprite.gameObject.TryGetComponent<Collider2D>(out Collider2D col))
        {
            col.enabled = false;
        }

        while (c.a < 1f)
        {
            c.a += Time.deltaTime * fadeSpeed;
            targetSprite.color = c;
            yield return null;
        }

        c.a = 1f;
        targetSprite.color = c;

        
        ActivateTreeCollider(targetSprite.gameObject);

        Destroy(gameObject);
    }

    private void ActivateTreeCollider(GameObject target)
    {
        if (target.TryGetComponent<Collider2D>(out Collider2D col))
        {
            col.enabled = true;
        }
    }
}