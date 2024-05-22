using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource audioSource;
    public AudioClip[] backgroundMusicClip; //여러 효과음 받을 것 대비해 배열로 바꾸는 것 추천.
    public AudioClip[] SFXClip;

    public AudioClip[] backgroundMusicClips = new AudioClip[4];
    void Awake()
    {
        // 싱글톤 패턴 구현
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // AudioSource 컴포넌트를 가져오기
        audioSource = GetComponent<AudioSource>();
       
        // 배경음악은 반복 재생 설정
        if (audioSource != null)
        {
            audioSource.loop = true;
        }
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬이 로드될 때 배경음악 재생
        PlayBackgroundMusic(scene.buildIndex);
    }

    public void PlayBackgroundMusic(int index)
    {
        if (index >= 0 && index < backgroundMusicClip.Length && audioSource != null)
        {
            // 배경음악을 교체하고 재생
            if (audioSource.clip != backgroundMusicClip[index])
            {
                audioSource.clip = backgroundMusicClip[index];
                audioSource.Play();
            }
        }
    }

    // 효과음 재생 함수
    public void PlaySFX(int index)
    {
        if (index >= 0 && index < SFXClip.Length && audioSource != null)
        {
            audioSource.PlayOneShot(SFXClip[index]);
        }
    }

    // 배경음악 볼륨 조절 함수
    public void AdjustVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = Mathf.Clamp(volume, 0f, 1f);
        }
    }

    // 볼륨을 설정할 수 있는 효과음 재생 메서드
    public void PlaySFX(int index, float volume)
    {
        if (index >= 0 && index < SFXClip.Length && audioSource != null)
        {
            AudioSource.PlayClipAtPoint(SFXClip[index], transform.position, volume);
        }
    }

        // 불륨 기본값
        public float GetVolume()
    {
        return audioSource != null ? audioSource.volume : 0.2f;
    }
}