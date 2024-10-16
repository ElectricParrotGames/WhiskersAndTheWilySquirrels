using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


[CreateAssetMenu(fileName = "new Archetype", menuName ="Archetype")]
public class Archetype : ScriptableObject
{
    [Header("if false, will be idle")]
    public bool needBehaviour;

    [ConditionalHide("needBehaviour", true)]
    public bool canPatrol = false;
    [ConditionalHide("canPatrol", true)]
    public float patrolSpeed;

    [ConditionalHide("needBehaviour", true)]
    public bool canCollect;
    [ConditionalHide("canCollect", true)]
    public float collectSpeed;
    [ConditionalHide("canCollect", true)]
    public bool canEat;
    [ConditionalHide("canCollect", true)]
    public bool canBury;

    [ConditionalHide("needBehaviour", true)]
    public bool canAttack;
    [ConditionalHide("canAttack", true)]
    public bool canThrow;
    [ConditionalHide("canThrow", true)]
    public float minTimeBetweenThrow;
    [ConditionalHide("canThrow", true)]
    public ThrowMethod throwMethod;
    [ConditionalHide("canAttack", true)]
    public bool canChase;
    [ConditionalHide("canChase", true)]
    public float chaseSpeed;
    [ConditionalHide("canChase", true)]
    public float waitBetweenChase;

}
