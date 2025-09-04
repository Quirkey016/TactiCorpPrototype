using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnsureSingularPoint : MonoBehaviour
{
    //ref to this gameobject
    private static GameObject _instance;
    //ref to the player
    private Player _player;

    private void Awake()
    {
        //fills the player ref
_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

//if there is no instance make this the instance
        if (_instance == null)
        {
            _instance = gameObject;
        }

        //in any other senario destroy this
        else
        {
            Destroy(gameObject);
        }

        //move the instance to the position of the players HIT ray but slightly up so its visable
        _instance.transform.position = _player.Hit.point += new Vector3(0, 0.1f, 0);
    }



    private void OnDrawGizmos()
    {
        //shows where the invisible point is without clicking on it
        Gizmos.DrawWireSphere(transform.position, 1.5f); //this is totaly arbitrary and only helps development
        //todo remove on launch
    }

    private void Update()
    {
        //if there is no instance return and dont go any further
        if (!_instance) return;
        //if the instances position is not the same as the players than move it to be there but offset
        if (_instance.transform.position != _player.Hit.point)
        {
            _instance.transform.position = _player.Hit.point += new Vector3(0, 0.1f, 0);
        }
    }
}
