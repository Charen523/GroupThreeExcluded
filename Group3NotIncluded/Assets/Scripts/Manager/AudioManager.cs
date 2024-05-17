using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;
    public AudioClip clip; //여러 효과음 받을 것 대비해 배열로 바꾸는 것 추천.

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = this.clip;
        audioSource.Play();
    }

    // 배경음악 볼륨 조절 함수
    public void AdjustVolume()
    {

    }
}