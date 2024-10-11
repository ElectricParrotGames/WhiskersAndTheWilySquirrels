using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    public static GameMaster instance;
    private GameObject[] squirrels;
    private GameObject[] catnips;
    public int level { get; private set; } = 0;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        instance = this;
        level = PlayerPrefs.GetInt("level");
    }

    void Start()
    {
        squirrels = GameObject.FindGameObjectsWithTag("Squirrel");
        catnips = GameObject.FindGameObjectsWithTag("Catnip");

        foreach (GameObject squirrel in squirrels)
        {
            foreach (GameObject catnip in catnips)
            {
                squirrel.GetComponentInChildren<Collect>().catnips.Add(catnip.transform);
            }
            
        }
    }

    void Update()
    {

    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("level", level);
    }
}
