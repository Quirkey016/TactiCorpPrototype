using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class TurnManager : MonoBehaviour
{
   public bool playerTurn = true;
   public int turnCount = 0;
   [SerializeField] private TextMeshProUGUI turnText;
   [SerializeField] private Player player;

   public void NextTurn()
   {
       playerTurn = playerTurn switch
       {
           true => false,
           false => true,
       };

       turnCount++;
       turnText.text = "Turn: " + turnCount;
   }
}
