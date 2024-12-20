using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public int saveIndex;
    public static GameMaster instance;
    private List<Transform> catnips = new List<Transform>();
    public GameObject escapeMenu;
    public GameObject lifeContainer;
    public GameObject catnipContainer;
    public AudioSource src;

    private void Awake()
    {
        instance = this;
        saveIndex = -1;
        escapeMenu.SetActive(false);
        lifeContainer.SetActive(false);
        catnipContainer.SetActive(false);
        src.Play();
    }

    public List<Transform> GetAllCatnips()
    {
        return catnips;
    }

    public int GetTotalNumberCatnips()
    {
        return catnips.Count;
    }

    public void FinishLevel()
    {
        LevelNavigator.instance.GoToNextScene();
    }

    public void StartFresh()
    {
        catnips = new List<Transform>();
        foreach (var obj in FindObjectsOfType<Transform>(true))
        {
            if (obj.CompareTag("Catnip"))
            {
                catnips.Add(obj);
            }
        }

        src.volume = GameSetting.SoundVolume;
        UIManager.instance.SetTotalCatnipText();
    }

    private void Update()
    {
        int buildScene = SceneManager.GetActiveScene().buildIndex;
        if (buildScene > 1 && buildScene < 5)
        {
            if (!lifeContainer.activeInHierarchy || !catnipContainer.activeInHierarchy) 
            {
                lifeContainer.SetActive(true);
                catnipContainer.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ActivateEscapeMenu(!escapeMenu.activeInHierarchy);
            }
        }
        else
        {
            if (lifeContainer.activeInHierarchy || catnipContainer.activeInHierarchy)
            {
                lifeContainer.SetActive(false);
                catnipContainer.SetActive(false);
            }
        }
    }

    public void ActivateEscapeMenu(bool isActive)
    {
        escapeMenu.SetActive(isActive);
    }
}
