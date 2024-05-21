using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBtn : MonoBehaviour
{
    public void OpenMusicVolume(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
        AudioManager.Instance.PlaySFX(0);
    }

    public void CloseMusicVolume(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
        AudioManager.Instance.PlaySFX(0);
    }
}
