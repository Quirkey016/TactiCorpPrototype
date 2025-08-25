using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnsureSingularPoint : MonoBehaviour
{
    private static GameObject _instance;
    private Player _player;

    private void Awake()
    {
_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (_instance == null)
        {
            _instance = gameObject;
        }

        else
        {
            Destroy(gameObject);
        }

        _instance.transform.position = _player.Hit.point += new Vector3(0, 0.1f, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }

    private void Update()
    {
        if (!_instance) return;
        if (_instance.transform.position != _player.Hit.point)
        {
            _instance.transform.position = _player.Hit.point += new Vector3(0, 0.1f, 0);
        }
    }
}
