using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public void OnRestartClick()
    {
        LevelNavigator.instance.ReloadScene();
        GameMaster.instance.ActivateEscapeMenu(false);
    }

    public void OnMainMenuClick()
    {
        LevelNavigator.instance.LoadScene(1);
        GameMaster.instance.ActivateEscapeMenu(false);
    }

    public void OnQuitClick()
    {
        LevelNavigator.instance.QuitApplication();
    }

    public void OnXClick()
    {
        GameMaster.instance.ActivateEscapeMenu(false);
    }
}
