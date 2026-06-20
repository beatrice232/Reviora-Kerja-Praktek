using UnityEngine;

public class FollowWorldPos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform target;
    public Vector3 worldOffset = new Vector3(0f, 2f, 0f);
    
    public void SetTarget(Transform t)
    {
        target = t;
    }

    private void Update()
    {
        if (target == null || Camera.main == null) return;
        {
            Vector3 ScreenPos = Camera.main.WorldToScreenPoint(target.position + worldOffset);
            transform.position = ScreenPos;
        } 
    }

}