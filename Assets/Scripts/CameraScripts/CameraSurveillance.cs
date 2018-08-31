using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraScript
{
    public class CameraSurveillance : MonoBehaviour
    {
        public Camera[] cameras;           // Array of cameras to switch between
        public KeyCode nextKey = KeyCode.E;// KeyCode to switch to previous camera
        public KeyCode prevKey = KeyCode.Q;// KeyCode to switch to previous camera

        private int camIndex;               // Index into array of lookObjects
        private int camMax;                 // Stores the total amount of cameras
        private Camera current;             // Current target look object

        // Use this for initialization
        void Start()
        {
            cameras = GetComponentsInChildren<Camera>();// Get all camera children and store into array
            camMax = cameras.Length - 1;// Last index of array = Array.Length - 1
            ActivateCamera(camIndex);// Activate the default camera
        }

        void Update()// Update is called once per frame
        {
            if (Input.GetKeyDown(nextKey))// If the next key is pressed
            {
                camIndex++;// Increment index
                if (camIndex >= camMax)// If camIndex exceeds array size
                {
                    camIndex = 0; // Reset camIndex back to zero
                }
                ActivateCamera(camIndex);// Activate camera
            }

            if (Input.GetKeyDown(prevKey))// If the prev key is pressed
            {
                camIndex--;// Decrement index

                if (camIndex < 0)// If camIndex is below zero
                {
                    camIndex = camMax;// Set cam to last one in array
                }
                ActivateCamera(camIndex);// Activate camera
            }
        }

        void ActivateCamera(int camIndex)
        {
            for (int i = 0; i < cameras.Length; i++) // Loop through all surveillance cameras
            {
                Camera cam = cameras[i];

                if (i == camIndex)// If the current index matches the argument camIndex
                {
                    cam.gameObject.SetActive(true);// Enable this camera
                }
                else // ...otherwise
                {
                    cam.gameObject.SetActive(false);// Disable this camera
                }
            }
        }

    }
}