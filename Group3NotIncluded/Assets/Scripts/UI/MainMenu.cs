using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private Managers managers;
    private GameObject mainMenu;


    private void Awake()
    {
        managers = Managers.Instance;
    }
}