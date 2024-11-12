using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject SaveMenu;
    public GameObject ParamMenu;

    private void Start()
    {
        MainMenu.SetActive(true);
        SaveMenu.SetActive(false);
        ParamMenu.SetActive(false);
    }
    public void OnStartClick()
    {
        SaveMenu.SetActive(true);
        MainMenu.SetActive(false);
        ParamMenu.SetActive(false);
    }

    public void OnParametersClick()
    {
        ParamMenu.SetActive(!ParamMenu.activeInHierarchy);
    }

    public void OnQuitClick()
    {
        LevelNavigator.instance.QuitApplication();
    }
}
