using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : State
{
    public GameObject mouth;
    private float timer = 0f;
    private readonly float timeBeforeDisapearing = 2f;
    private bool hasDisapear = false;
    public override void Enter()
    {
        anim.Play("Death");
        ReleaseCatnip();
        
    }

    public override void Do()
    {
        timer += Time.deltaTime;
        if(timer >= timeBeforeDisapearing && !hasDisapear)
        {
            hasDisapear = true;
            transform.root.gameObject.SetActive(false);
            //Destroy(transform.parent.parent.gameObject);
        }
    }

    public override void FixedDo()
    {
       
    }
    public override void Exit()
    {

    }

    private void ReleaseCatnip() {
        for (int i = 0; i < mouth.transform.childCount; i++)
        {
            Vector2 direction = new Vector2((float)Random.Range(-0.5f, 0.5f), (float)Random.Range(1, 2));
            float force = (float)Random.Range(0.5f, 2);

            Transform catnip = mouth.transform.GetChild(i);
            catnip.position = mouth.transform.position;
            catnip.SetParent(null);
            catnip.gameObject.SetActive(true);
            catnip.GetComponent<CatnipScript>().AsReappear();

            Rigidbody2D catnipRb = catnip.GetComponent<Rigidbody2D>();
            catnipRb.velocity = direction * force;
        }
    }
}
