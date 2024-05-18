using UnityEngine;

public class SetActiveToggleBtn : MonoBehaviour
{
    //약간 문제가 있지만 작동은 함. 5.20 튜터 찾아가기.
    public void ToggleGameObject(GameObject obj)
    {
       obj.SetActive(!obj.activeSelf);
    }
}