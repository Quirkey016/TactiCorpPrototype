using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
  #region Vars

  //int for how much health somehting has
  public int health = 3;

  //ref to the hearts on UI //todo get these dynamicly so you dont have to manualy change it or make any overrides
  public GameObject heartOne;
  public GameObject heartTwo;

  #endregion


  public void Update()
  {
    /*
     this switch handles what happens as you lose health

     in the case there is 2 health left remove the 3rd HP

     in the case there is 1 health left remove the 2nd HP

     in the case there is 0 health left destroy the gameovject this is attached to
     */
    switch (health)
    {
      case 2:
        heartOne.SetActive(false);
        break;
      case 1:
        heartTwo.SetActive(false);
        break;
      case 0:
        Destroy(gameObject);
        break;
    }
    //todo dynamicly do this rather than this s***** hardcode
  }
}
