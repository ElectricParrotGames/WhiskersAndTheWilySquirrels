using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class CatnipScript : MonoBehaviour
{
    public bool CanBeTake { get; private set; } = true;
    private readonly float timeBeforeTake = 1f;
    // Start is called before the first frame update
    

    public void AsReappear()
    {
        CanBeTake = false;
        StartCoroutine(CanBeTakeBack());
    }

    private IEnumerator CanBeTakeBack()
    {
        yield return new WaitForSeconds(timeBeforeTake);
        CanBeTake = true;
    }
}
