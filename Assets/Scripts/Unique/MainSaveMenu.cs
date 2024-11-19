using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainSaveMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject SaveMenu;

    public TMP_Text save1Text;
    public TMP_Text save2Text;
    public TMP_Text save3Text;

    private string newGameText = "Nouvelle Partie";
    private string continuGameText = "Continuer Partie ";

    private void OnEnable()
    {
        string textSave1 = newGameText;
        string textSave2 = newGameText;
        string textSave3 = newGameText;

        if (SaveSystem.CheckHasSave(1))
        {
            textSave1 = continuGameText + "1";
        }
        save1Text.SetText(textSave1);

        if (SaveSystem.CheckHasSave(2))
        {
            textSave2 = continuGameText + "2";
        }
        save2Text.SetText(textSave2);

        if (SaveSystem.CheckHasSave(3))
        {
            textSave3 = continuGameText + "3";
        }
        save3Text.SetText(textSave3);
    }

    public void OnGame1Click()
    {
        SetSaveGame(1);
    }

    public void OnGame2Click()
    {
        SetSaveGame(2);
    }

    public void OnGame3Click()
    {
        SetSaveGame(3);
    }

    public void OnReturnClick()
    {
        MainMenu.SetActive(true);
        SaveMenu.SetActive(false);
    }

    private void SetSaveGame(int saveIndex)
    {
        GameMaster.instance.saveIndex = saveIndex;

        if (SaveSystem.CheckHasSave(saveIndex))
        {
            SaveSystem.GameState state = SaveSystem.LoadSaveDataFromSave(saveIndex);
            PlayerData.instance.life = state.currentLives;
            LevelNavigator.instance.LoadScene(state.sceneIndex);
        }
        else
        {
            LevelNavigator.instance.GoToNextScene();
        }
    }
}
