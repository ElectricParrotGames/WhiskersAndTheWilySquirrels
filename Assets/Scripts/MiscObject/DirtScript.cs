using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReleaseCatnip()
    {
        Vector2 direction = new Vector2((float)Random.Range(-0.5f, 0.5f), (float)Random.Range(1, 2));
        float force = (float)Random.Range(0.5f, 2);

        Transform catnip = this.transform.GetChild(0);
        if(catnip != null)
        {
            catnip.position = transform.position;
            catnip.SetParent(null);
            catnip.gameObject.SetActive(true);
            catnip.GetComponent<CatnipScript>().AsReappear();

            Rigidbody2D catnipRb = catnip.GetComponent<Rigidbody2D>();
            catnipRb.velocity = direction * force;
        }
        Destroy(this.gameObject);
    }
}
