using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource audioSource;
    public AudioClip[] backgroundMusiclip; //���� ȿ���� ���� �� ����� �迭�� �ٲٴ� �� ��õ.
    public AudioClip[] SFXClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.Play();
    }

    // ������� ���� ���� �Լ�
    public void AdjustVolume()
    {

    }
}