using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
   public float zoomSpeed = 10f;
   public float zoom;
   public float minSize = 1f;
   public float maxSize = 10f;
   private float _val;
   [SerializeField] private Camera playerCamera;


   private void Start()
   {
       zoom = playerCamera.orthographicSize;
   }

   private void Update()
   {
       ScrollZoom();
   }

   private void ScrollZoom()
   {

       var scrollData = Input.GetAxis("Mouse ScrollWheel");
           zoom -= scrollData * zoomSpeed;
           zoom = Mathf.Clamp(zoom, minSize, maxSize);
           playerCamera.orthographicSize = Mathf.SmoothDamp(playerCamera.orthographicSize, zoom, ref _val, 0.25f);
   }
}
