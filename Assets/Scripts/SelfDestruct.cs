using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(SelfDestructCoroutine());
    }

    private IEnumerator SelfDestructCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
