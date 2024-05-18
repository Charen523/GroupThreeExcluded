using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveToggleBtn : MonoBehaviour
{
    public void ToggleGameObject(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }
}
