using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{

    [SerializeField] private LayerMask clickableLayer;
    [SerializeField] private LayerMask uiLayer;
    //private Animator _animator;
    [SerializeField] private NavMeshAgent agent;
    private Camera _mainCamera;
    [SerializeField] private ParticleSystem clickEffect;
    [SerializeField] private GameObject wantedPosition;
    public RaycastHit Hit;
    [SerializeField] private bool isHovering;

// Start is called before the first frame update
    private void Awake()
    {
        //_animator = GetComponent<Animator>();
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
       if (Input.GetMouseButtonDown(0))
       {
           SetDestination();
       }
    }

    private bool IsPointerOverUIOnLayer()
    {
        // 1. Create a PointerEventData object
        var eventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        // 2. Create a list to store the raycast results
        var results = new List<RaycastResult>();

        // 3. Raycast against all UI elements
        EventSystem.current.RaycastAll(eventData, results);

        // 4. Check if any of the hit objects are on the specified layer
        return results.Any(result => (uiLayer & (1 << result.gameObject.layer)) != 0);
    }

    private void SetDestination()
    {
        isHovering = IsPointerOverUIOnLayer();
        if (isHovering) return;
        if (!Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out var hit, clickableLayer)) return;
        Instantiate(wantedPosition, hit.point, Quaternion.identity);
        Hit = hit;
        if (clickEffect)
        {
            Instantiate(clickEffect, hit.point += new Vector3(0, 0.1f, 0), clickEffect.transform.rotation);
        }
        agent.destination = new Vector3(wantedPosition.transform.position.x, wantedPosition.transform.position.y, wantedPosition.transform.position.z);
    }
}
