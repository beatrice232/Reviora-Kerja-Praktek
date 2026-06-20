using UnityEngine;

public class TreeCounter : MonoBehaviour
{
    public static TreeCounter Instance;
    public int targetPohon = 4;
    private int pohonDitanam = 0;

    [SerializeField] private BgFadeout bgFadeout;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Instance = this;
        pohonDitanam = 0;
    }

    // Update is called once per frame
    public void PohonDitanam()
    {
        pohonDitanam++;
        Debug.Log("Pohon ditanam:" + pohonDitanam);
        if(pohonDitanam >= targetPohon)
        {
            if (bgFadeout != null)
            {
                bgFadeout.FadeOut();
            }
            else
            {
                Debug.LogError("ga ke assign");
            }

        }
    }
}
