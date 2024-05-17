using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = this.clip;
        audioSource.Play();
    }

    // ¹è°æÀ½¾Ç º¼·ý Á¶Àý ÇÔ¼ö
    public void AdjustVolume()
    {

    }
}