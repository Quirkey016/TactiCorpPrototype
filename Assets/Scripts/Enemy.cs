
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    //this is a ref to the turn manager
    [SerializeField] private TurnManager turnManager;
    //this si a ref to the player
    [SerializeField] private GameObject playerObject;
    //this is the distance the enemy can see the player
    public float sightDistance;
    //ref to the agent of this
    [SerializeField] private NavMeshAgent enemyAgent;
    //flaot to hold the distnace of the player to this
    private float _distance;

    private bool PlayerIsInRange()
    {
        //this gets the distance from the player to this and returns true of false if that distance is grater or lesser than the sight of the enemy
        _distance = Vector3.Distance(playerObject.transform.position, gameObject.transform.position);
        return !(_distance > sightDistance);
    }

    private void Start()
    {
        //fills refs for the player and turn manager (gamemanager)
        playerObject = GameObject.FindGameObjectWithTag("Player");
        turnManager = GameObject.FindGameObjectWithTag("TurnManager").GetComponent<TurnManager>();
    }

    private void OnDrawGizmos()
    {
        //shows the "sight" of the enemy in the scene
        Gizmos.DrawWireSphere(transform.position, sightDistance);
    }

    //method to move the enemy
    private void MoveToPlayer()
    {
        //moves the agent to the player
        enemyAgent.destination = (playerObject.transform.position);
    }

    private void Update()
    {
        //if the player is not in range or if its the players turn return and go no further. otherwise move the player
        if (!PlayerIsInRange() || turnManager.turn == 1) return;
      MoveToPlayer();
    }

}

