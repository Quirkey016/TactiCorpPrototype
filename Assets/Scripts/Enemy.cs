
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private GameObject playerObject;
    public float sightDistance;
    [SerializeField] private NavMeshAgent enemyAgent;
    private float _distance;

    private bool PlayerIsInRange()
    {
        _distance = Vector3.Distance(playerObject.transform.position, gameObject.transform.position);
        return !(_distance < sightDistance);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sightDistance);
    }

    private void MoveToPlayer()
    {
        if (!PlayerIsInRange() || turnManager.playerTurn) return;
        enemyAgent.destination
            = (playerObject.transform.position)
            += new Vector3(playerObject.transform.position.x - _distance, gameObject.transform.position.y, playerObject.transform.position.z - _distance);
        turnManager.playerTurn = true;
    }

    private void Update()
    {
      MoveToPlayer();
    }

}

