using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    #region MyRegion
    //floats
    //this float controld the speed the camm zooms at
   public float zoomSpeed = 10f;
   //this float holds the current zoom level of the cam as a float
   public float zoom;
   //holds the min zoom size, i.e. how zoomed in you can go
   public float minSize = 1f;
   //this handles the opposite of the previous float
   public float maxSize = 10f;
   // this is a ref to the velocity the cam is going
   private float _val;

   //this is a ref to the main cam in the scene
   [SerializeField] private Camera playerCamera;
   #endregion

   private void Start()
   {
       //this ensures the cam is set the whatever the cam zoom already was (the use of this is to keep zoom across levels for player prefs)
       zoom = playerCamera.orthographicSize;
   }

   private void Update()
   {
       //runs the ScrollZoom method
       ScrollZoom();
   }

   //handles the zooming of the camera
   private void ScrollZoom()
   {
//this float holds the data of the mouse scrolling as a float
       var scrollData = Input.GetAxis("Mouse ScrollWheel");

            //uses the scroll data to change the zoom float. zoom speed changes the speed of this change
           zoom -= scrollData * zoomSpeed;

           //this clams the min and max the player can zoom by the limits set
           zoom = Mathf.Clamp(zoom, minSize, maxSize);

           //this actualy changes the cams zoom level. it uses a velocity to do it smoothly
           playerCamera.orthographicSize = Mathf.SmoothDamp(playerCamera.orthographicSize, zoom, ref _val, 0.25f); // sorry, magic number, its the time to smooth the cam change //todo remove magic number
   }
}
