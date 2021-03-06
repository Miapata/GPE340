﻿using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Environments;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject target;
    public Animator animator;
    public float speed;
    public bool delete;
    public bool isDead;
    public PickupsManager.Items equppiedItem;
    public GameObject child1, child2;
    private Vector3 desiredVelocity;
    private Collider[] collisionCheck;
    private Health health;
    private Pawn pawn;

    private HealthEvents healthEvents;
    // Use this for initialization
    void Start()
    {
        child1 = transform.GetChild(0).gameObject;
        child2 = transform.GetChild(1).gameObject;
        //Set the HealthEvents component
        healthEvents = GetComponent<HealthEvents>();
        // Set the NavMeshAgent component
        navMeshAgent = GetComponent<NavMeshAgent>();
        // Set the Animator component
        animator = GetComponent<Animator>();
        // Set the Pawn component
        pawn = GetComponent<Pawn>();
        //Get the Health component
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        // If we are dead disable our movement and attack
        if (!isDead)
        {
            Movement();
            Attack();
        }
        if (delete)
        {
            Destroy(gameObject);

        }

    }
    //Jesus Christ
    private void OnAnimatorMove()
    {
        //Set our agent's velocity to the animator's velocity.
        navMeshAgent.velocity = animator.velocity;
    }

    void Movement()
    {
        if (navMeshAgent.isActiveAndEnabled == true && navMeshAgent.isOnNavMesh)
        {

            navMeshAgent.SetDestination(target.transform.position);
        }
        desiredVelocity = Vector3.MoveTowards(desiredVelocity, navMeshAgent.desiredVelocity, navMeshAgent.acceleration * Time.deltaTime);
        Vector3 input = transform.InverseTransformDirection(desiredVelocity * speed);
        animator.SetFloat("Horizontal", input.x);
        animator.SetFloat("Vertical", input.z);
    }
    void Respawn()
    {
        health.health = 1;
        healthEvents.OnSpawn.Invoke();
        gameObject.SetActive(false);
        Vector3 newPosition = new Vector3(Random.Range(-11, 7), 0, Random.Range(-11, 5));
        collisionCheck = Physics.OverlapSphere(target.transform.position, 5);
        foreach (var colliderObject in collisionCheck)
        {
            if (colliderObject.tag == "Player")
            {
                Debug.Log("In player's radius");
                return;
            }
            else
            {
                gameObject.transform.position = newPosition;
                gameObject.SetActive(true);
                isDead = false;
            }
        }
    }
    void Attack()
    {
        if (GetComponent<FOV>() != null)
            if (!GetComponent<FOV>().isInFov || GetComponent<Pawn>().weaponPlacementPoint.childCount == 0)
                return;
        if (GetComponent<Pawn>().weaponPlacementPoint.GetChild(0))
        {
            switch (equppiedItem)
            {
                case PickupsManager.Items.M4:

                    Fire();

                    break;
                case PickupsManager.Items.Sword:
                    animator.Play("Attack_Sword");
                    break;
                default:
                    break;
            }
        }
    }

    private void Fire()
    {
        pawn.equppiedItem.GetComponent<M4>().Fire();
    }

}
