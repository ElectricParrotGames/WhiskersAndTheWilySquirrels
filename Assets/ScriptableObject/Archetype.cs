using UnityEngine;

[CreateAssetMenu(fileName = "new Archetype", menuName = "Archetype")]
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
    public float minTimeBetweenAttack;
    [ConditionalHide("canAttack", true)]
    public bool canThrow;
    [ConditionalHide("canThrow", true)]
    public ThrowMethod throwMethod;
    [ConditionalHide("canAttack", true)]
    public bool canChase;
    [ConditionalHide("canChase", true)]
    public float chaseSpeed;

}
