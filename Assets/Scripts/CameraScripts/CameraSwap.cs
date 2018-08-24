using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CameraScript
{
    public class CameraSwap : MonoBehaviour
    {
        #region Variables
        public Transform[] lookObject;
        public bool smooth = true;
        public float damping = 6;
        [Header("GUI")]
        public float scrW;
        public float scrH;

        private int camIndex;
        private int camMax;
        private Transform target;
        #endregion

        // Use this for initialization
        void Start()
        {
            camMax = lookObject.Length - 1;
        }

        // Update is called once per frame
        void Update()
        {
            target = lookObject[camIndex];
            if (target)
            {
                if (smooth)
                {
                    Vector3 lookDirection = target.position - transform.position;
                    Quaternion rotation = Quaternion.LookRotation(lookDirection);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
                }
                else
                {
                    transform.LookAt(target);
                }
            }
            else
            {
                CamSwap();
            }
        }
        void CamSwap()
        {
            camIndex++;
            if (camIndex > camMax)
            {
                camIndex = 0;
            }
        }
        private void OnGUI()
        {
            if (scrW != Screen.width / 16 || scrH != Screen.height / 9)
            {
                scrW = Screen.width / 16;
                scrH = Screen.height / 9;
            }
            if (GUI.Button(new Rect(scrW * 0.5f, scrH * 0.25f, scrW * 1.5f, scrH * 0.75f), "Swap"))
            {
                CamSwap();
            }
        }
    }
}
