using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    public static GameMaster instance;
    private GameObject[] squirrels;
    private GameObject[] catnips;

    private void Awake()
    {
        instance = this;
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
}
