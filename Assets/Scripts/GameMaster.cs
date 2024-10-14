using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    public static GameMaster instance;
    private GameObject[] squirrels;
    private List<Transform> catnips = new List<Transform>();
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

        foreach (var obj in FindObjectsOfType<Transform>(true))
        {
            if (obj.CompareTag("Catnip"))
            {
                catnips.Add(obj);
            }
        }

        foreach (GameObject squirrel in squirrels)
        {
            foreach (Transform catnip in catnips)
            {
                squirrel.GetComponentInChildren<Collect>().catnips.Add(catnip);
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
