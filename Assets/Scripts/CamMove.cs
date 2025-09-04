using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
  //this is a ref to what we want the cam to follow
  public Transform target;

  private void Update()
  {
    //this moves whatever the scripts it attached to to a vecter 3 defined as this.position.X, targets.Y at a speed of framerate
    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target.position, Time.deltaTime);
  }
}
