using UnityEngine;

public class SetActiveToggleBtn : MonoBehaviour
{
    //�ణ ������ ������ �۵��� ��. 5.20 Ʃ�� ã�ư���.
    public void ToggleGameObject(GameObject obj)
    {
       obj.SetActive(!obj.activeSelf);
    }
}