﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ThirdPersonController { 
namespace CameraScript
{
    public class CameraController : MonoBehaviour
    {

        public Transform target;
        private Vector3 offset;

        // Use this for initialization
        void Start()
        {
            offset = transform.position - target.position;
            target = GameObject.Find("Player").transform;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = target.position + offset;
        }
    }
}
}