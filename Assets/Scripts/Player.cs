using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    //these are layermasks to self explanitory layers
    [SerializeField] private LayerMask clickableLayer;
    [SerializeField] private LayerMask uiLayer;
    [SerializeField] private LayerMask enemyLayer;


    //this is the distance the player can attack at //todo add the weapons, currently the player is a meele character not good
    [SerializeField] public float attackDistance;

    //ref to the agent
    [SerializeField] public NavMeshAgent agent;

    //ref to the main cam
    private Camera _mainCamera;

    //ref the the particle that appears when you click
    [SerializeField] private ParticleSystem clickEffect;

    //ref to the prefab that gets instanciated to gve the player direction
    [SerializeField] private GameObject wantedPositionClone;
    //ref to the actioal destination of the player
    [CanBeNull] public GameObject wantedPosition;
    //public holding of private raycast to tell the game where the player wants to go
    public RaycastHit Hit;
    //int that holds how many turns the player has
    public int actionsLeft = 5;
    //UI for said AP
    public TextMeshProUGUI actionText;

    private void Awake()
    {
       //gets the main cam on awake, duh
        _mainCamera = Camera.main;
    }


    private void Update()
    {
        //if the player clicks and they have more that 0 actions run methods
       if (Input.GetMouseButtonDown(0))
       {
           if (actionsLeft > 0)
           {
               SetDestination();
               AttackEnemy();
           }
           //update UI
           actionText.text = actionsLeft + " : AP";
       }

       //if there is a destination for the player move
       if ( wantedPosition)
       {
           //move the player to said destination but keep your y
           agent.destination = new Vector3( wantedPosition!.transform.position.x,  gameObject.transform.position.y,
               wantedPosition!.transform.position.z);
       }

       //run bool mehtod that tells of the cursor is on ui
       IsPointerOverUIOnLayer();
    }


    //bool to tell if cursor is on ui
    private bool IsPointerOverUIOnLayer()
    {
        // Creates a PointerEventData object
        var eventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        //  a list to store the raycast results
        var results = new List<RaycastResult>();

        //  Raycast against all UI elements
        EventSystem.current.RaycastAll(eventData, results);

        //  Check if any of the hit objects are on the specified layer
        return results.Any(result => (uiLayer & (1 << result.gameObject.layer)) != 0);
    }


    private void OnDrawGizmos()
    {
        //show the distance the player can attack //todo ADD THE F****** GUNS YOU LAZY W****, F***
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }

    private void AttackEnemy()
    {
        //cast a ray from the cam to the cursor and if it hits an enemy than set what you hit to target and get its health if it has one then deduct health if its in range, finaly remove AP
        if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out var enemyHit, enemyLayer))
        {
            var target = enemyHit.collider;
            var distance = Vector3.Distance(target.transform.position, gameObject.transform.position);
            if (distance < attackDistance)
            {
                var enemy = target.gameObject;
                enemy.GetComponent<HealthManager>().health--;
                actionsLeft--;
            }
        }
    }

    private void SetDestination()
    {
        //cast a ray from the cam to the cursor and if it hits ground than create a destination for the player to go and fill Hit var with hit and decuct AP. all only if your not on UI layer
        if (IsPointerOverUIOnLayer()) return;
                if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out var hit, Mathf.Infinity,clickableLayer))
                {
                    Instantiate(wantedPositionClone, hit.point, Quaternion.identity);
                    wantedPosition = GameObject.Find("WantedPos(Clone)");
                    Hit = hit;
                    if (clickEffect)
                    {
                        Instantiate(clickEffect, hit.point += new Vector3(0, 0.1f, 0), clickEffect.transform.rotation);
                    }
                    actionsLeft--;
                }
    }
}
