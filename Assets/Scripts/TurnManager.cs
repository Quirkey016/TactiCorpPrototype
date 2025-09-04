using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class TurnManager : MonoBehaviour
{
    #region Variables
    //ref to text that tells whos turn it currenly is
    [SerializeField] private TextMeshProUGUI whosTurnText;

    //ref to player
    public Player playerScript;

    //this int tracks whos turn it is. one is the player and 2 is the enemy (its an int not a bool so we can expand if there is more factions and or a third party of any kind including multiplayer)
     public int turn = 1;

#endregion

   public void Start()
   {
       //finds the player and fills the ref
      playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

      //sets the text to be your turn off rip (here incase there is a level you are not first)
      whosTurnText.text = "Your Turn";
   }


   //method to handle turn stepping, called via UI button
   public void NextTurn()
   {
       /*
        this switch handles the logic behind whos turn it is
        firstly when its called if its the players turn (1) then we set it to 2 (enemy) and vica verca
        so when the method is called the turn "stats" changes
        we also change the whosTurnText to represent the apropriate turn
        only is case 1 we set AP to 5 (or whatever we want) and update the UI to show this
        */
       switch (turn)
       {
           case 1:
               turn = 2;
               whosTurnText.text = "Your Turn";
               playerScript.actionsLeft = 5;
               playerScript.actionText.text = playerScript.actionsLeft + " : AP";
               break;
           case 2:
               turn = 1;
               whosTurnText.text = "Enemy Turn";
               break;
       }
   }
}
