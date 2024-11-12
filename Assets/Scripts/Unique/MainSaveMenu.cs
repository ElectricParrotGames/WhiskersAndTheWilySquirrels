using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSaveMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject SaveMenu;


    private void OnEnable()
    {
        //Check save game
    }

    public void OnGame1Click()
    {
        //Load first save
    }

    public void OnGame2Click()
    {
        //Load second save
    }

    public void OnGame3Click()
    {
        //Load third save
    }

    public void OnReturnClick()
    {
        MainMenu.SetActive(true);
        SaveMenu.SetActive(false);
    }
}
