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
            // ����: ù ��° ��������� ���
            PlayBackgroundMusic(0);
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
        else
        {
            Debug.LogWarning("Background music index out of range: " + index);
        }
    }

    // ȿ���� ��� �Լ�
    public void PlaySFX(int index)
    {
        if (index >= 0 && index < SFXClip.Length && audioSource != null)
        {
            audioSource.PlayOneShot(SFXClip[index]);
        }
        else
        {
            Debug.LogWarning("SFX index out of range or AudioSource is missing: " + index);
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