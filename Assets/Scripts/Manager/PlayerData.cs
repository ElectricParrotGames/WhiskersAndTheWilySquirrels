using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;
    private int basePlayerTotalLife = 9;
    public int life;

    private void Awake()
    {
        instance = this;
        life = basePlayerTotalLife;
    }




}
