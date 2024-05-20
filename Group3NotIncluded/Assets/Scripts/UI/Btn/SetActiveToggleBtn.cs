using UnityEngine;

public class SetActiveToggleBtn : MonoBehaviour
{
    public void ToggleGameObject(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
        // 효과음 재생
        AudioManager.Instance.PlaySFX(0);
    }
}