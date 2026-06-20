using UnityEngine;
using System.Collections;

public class PlantSeed : MonoBehaviour
{
    public int seedCount = 0;

    public void AddSeed()
    {
        seedCount++;
        Debug.Log("ADD -> " + gameObject.name + " = " + seedCount);
    }
    public bool UseSeed()
    {
        if (seedCount > 0)
        {
            seedCount--;
            return true;
        }
        Debug.Log("Seed no havesssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss");
        return false;
    }

}