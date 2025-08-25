using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
  public Transform target;

  private void Update()
  {
    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target.position, Time.deltaTime);
  }
}
