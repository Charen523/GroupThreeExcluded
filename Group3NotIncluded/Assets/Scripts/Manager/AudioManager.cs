using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource audioSource;
    public AudioClip[] backgroundMusicClip; //���� ȿ���� ���� �� ����� �迭�� �ٲٴ� �� ��õ.
    public AudioClip[] SFXClip;

    void Awake()
    {
        // �̱��� ���� ����
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

        // AudioSource ������Ʈ�� ��������
        audioSource = GetComponent<AudioSource>();
       
        // ��������� �ݺ� ��� ����
        if (audioSource != null)
        {
            audioSource.loop = true;
        }
    }

    void Start()
    {
        if (audioSource != null)
        {
            
            PlayBackgroundMusic(0);
            PlaySFX(0);
        }
    }
    public void PlayBackgroundMusic(int index)
    {
        if (index >= 0 && index < backgroundMusicClip.Length && audioSource != null)
        {
            // ��������� ��ü�ϰ� ���
            audioSource.clip = backgroundMusicClip[index];
            audioSource.Play();
        }
    }

    // ȿ���� ��� �Լ�
    public void PlaySFX(int index)
    {
        if (index >= 0 && index < SFXClip.Length && audioSource != null)
        {
            audioSource.PlayOneShot(SFXClip[index]);
        }
    }

    // ������� ���� ���� �Լ�
    public void AdjustVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = Mathf.Clamp(volume, 0f, 1f);
        }
    }
}