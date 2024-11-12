using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    public static GameMaster instance;
    private List<Transform> catnips = new List<Transform>();
    public int level { get; private set; } = 0;
    public bool LevelDone { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        instance = this;
        level = PlayerPrefs.GetInt("level");

        foreach (var obj in FindObjectsOfType<Transform>(true))
        {
            if (obj.CompareTag("Catnip"))
            {
                catnips.Add(obj);
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("level", level);
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
        LevelDone = true;
    }
}
