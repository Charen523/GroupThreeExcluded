using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;
    public AudioClip clip; //���� ȿ���� ���� �� ����� �迭�� �ٲٴ� �� ��õ.

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = this.clip;
        audioSource.Play();
    }

    // ������� ���� ���� �Լ�
    public void AdjustVolume()
    {

    }
}