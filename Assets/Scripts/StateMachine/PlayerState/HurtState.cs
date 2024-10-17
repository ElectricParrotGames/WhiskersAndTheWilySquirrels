using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class HurtState : State
{
    public GameObject pocket;
    /// <summary>
    /// Drop percentage only takes values between 0.01 to 0.99
    /// </summary>
    private float dropPercentage = 0.33f;
    private int numberCatnipRelease;
    private int amountOfCatnipDropped;

    public override void Enter()
    {
        numberCatnipRelease = 0;

        int catnipCount = pocket.transform.childCount;

        amountOfCatnipDropped = (int)(catnipCount * dropPercentage);

        if (catnipCount < 3)
        {
            amountOfCatnipDropped = catnipCount;
        }
    }

    public override void Do()
    {
        if(numberCatnipRelease == amountOfCatnipDropped)
        {
            isComplete = true;
        }
        else { 
            ReleaseCatnip(); 
        }
    }

    public override void FixedDo()
    {

    }
    public override void Exit()
    {

    }

    private void ReleaseCatnip()
    {
        Vector2 direction = new Vector2((float)Random.Range(-0.5f, 0.5f), (float)Random.Range(1, 2));
        float force = (float)Random.Range(0.5f, 2);

        Transform catnip = pocket.transform.GetChild(0);
        catnip.position = pocket.transform.position;
        catnip.SetParent(null);
        catnip.gameObject.SetActive(true);
        catnip.GetComponent<CatnipScript>().AsReappear();

        Rigidbody2D catnipRb = catnip.GetComponent<Rigidbody2D>();
        catnipRb.velocity = direction * force;

        numberCatnipRelease++;
    }
}