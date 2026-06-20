using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSourceip;
    public AudioClip background;
    public AudioClip Contamination;
    public AudioClip vacum;
    public AudioClip tombol;
    public AudioClip jalan;
    public AudioClip spray;
    public AudioClip nananm;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void PLaySFX(AudioClip clip)
    {
        SFXSourceip.PlayOneShot(clip);
    }
    
}
