using UnityEngine;

public class SetActiveToggleBtn : MonoBehaviour
{
    public void ToggleGameObject(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
        // ȿ���� ���
        AudioManager.Instance.PlaySFX(0);
    }
}