using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    public static GameMaster instance;
    private List<Transform> catnips = new List<Transform>();

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {

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
         StartFresh();
    }

    public void StartFresh()
    {
        Debug.Log("Scene started");
        catnips = new List<Transform>();
        foreach (var obj in FindObjectsOfType<Transform>(true))
        {
            if (obj.CompareTag("Catnip"))
            {
                catnips.Add(obj);
            }
        }
    }
}
