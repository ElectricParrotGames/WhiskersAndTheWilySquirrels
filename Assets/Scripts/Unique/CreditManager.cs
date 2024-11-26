using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditManager : MonoBehaviour
{

   public void OnNewGameClick()
    {
        int lifeValue = (int)GameSetting.LifeValue;
        GameSetting.LifeValue = lifeValue - 1 > 0 ? lifeValue - 1 : lifeValue;
        PlayerData.instance.life = (int)GameSetting.LifeValue;
        LevelNavigator.instance.LoadScene(2);
    }

    public void OnMainMenuClick()
    {
        LevelNavigator.instance.LoadScene(1);
    }
}
