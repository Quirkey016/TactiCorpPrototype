using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private void Awake()
    {
        //from the moment this object exists start the coroutine
        StartCoroutine(SelfDestructCoroutine());
    }


    //destroys an object after set time
    private IEnumerator SelfDestructCoroutine()
    {
        //waits for 1 second
        yield return new WaitForSeconds(1f); //this number represents the seconds to wait //todo change another magic number here

        //destroy the objet this scripts is attached to
        Destroy(gameObject);
    }
}
