﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace ThirdPersonController {
public class Enemy : MonoBehaviour
{
    //Declaration
    public enum State
    {
        Patrol,
        Seek
    }

    public State currentState = State.Patrol;
    public Transform target;
    public float seekRadius = 5f;

    public float moveSpeed;
    public float stoppingDistance = 1f;

    public NavMeshAgent agent;
    public Transform waypointParent;

    //Make a collection of transforms
    private Transform[] waypoints;
    private int currentindex = 1;

    public int health = 10;

    void Patrol()
    {
        Transform point = waypoints[currentindex];
        float distance = Vector3.Distance(transform.position, point.position);

        if (distance < stoppingDistance)
        {
            currentindex++;
            if (currentindex >= waypoints.Length)
            {
                currentindex = 1;
            }
        }

        agent.SetDestination(point.position);

        float disToTarget = Vector3.Distance(transform.position, target.position);
        if (disToTarget < seekRadius)
        {
            currentState = State.Seek;
        }
    }

    void Seek()
    {
        agent.SetDestination(target.position);
        float disToTarget = Vector3.Distance(transform.position, target.position);
        if (disToTarget > seekRadius)
        {
            currentState = State.Patrol;
        }
    }

    void Start()
    {
        //Getting childern of the waypointParent;
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = moveSpeed;
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Seek:
                Seek();
                break;
            default:Debug.Log("Something went wrong!");
                break;
        }
        if (health <= 0) 
        {
            Destroy(gameObject);
        }
        
    }
    public void DealDamage(int damage)
    {
        health -= damage;
    }
}
 }