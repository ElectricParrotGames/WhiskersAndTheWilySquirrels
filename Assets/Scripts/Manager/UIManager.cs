using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TMP_Text textNumberCatnip;
    public TMP_Text textTotalNumberCatnip;
    public List<GameObject> lifeImages;
    public GameObject gameOverPanel;


    private void Awake()
    {
        instance = this;
        ActivateGameOverPanel(false);
    }

    public void UpdateCatnipsNumber(int catnipOnPlayer)
    {
        textNumberCatnip.SetText(catnipOnPlayer.ToString());
        
    }

    public void UpdateLifeContainer(int lifeRemaining)
    {
        for (int i = 0; i < lifeImages.Count; i++)
        {
            lifeImages[i].SetActive(i < lifeRemaining);
        }
    }

    public void SetTotalCatnipText()
    {
        string textTotalCatnip = "/ " + GameMaster.instance.GetTotalNumberCatnips();
        textTotalNumberCatnip.SetText(textTotalCatnip);
    }

    public void ActivateGameOverPanel(bool isActive)
    {
        gameOverPanel.SetActive(isActive);
    }

}
