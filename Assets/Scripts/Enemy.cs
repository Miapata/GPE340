using System.Collections;
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
    public bool isDead;
    public PickupsManager.Items equppiedItem;

    private Vector3 desiredVelocity;
    private Collider[] collisionCheck;
    private Health health;
    private Pawn pawn;

    private HealthEvents healthEvents;
    // Use this for initialization
    void Start()
    {
        healthEvents = GetComponent<HealthEvents>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        pawn = GetComponent<Pawn>();
        //Get the health component
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jesus Christ Jesus Christ Jesus Christ 
<<<<<<< HEAD
=======
<<<<<<< HEAD
        if (navMeshAgent.isActiveAndEnabled == true&&navMeshAgent.isOnNavMesh)
=======
        if (navMeshAgent.isActiveAndEnabled == true&&isDead==false)
>>>>>>> 9bbd4aa3c2d4ba6f03c85a8540acfb7393919455
        {
>>>>>>> 5edcf099e632e69fc2f9e33d607cdcf7ac9e8f78

        Movement();
        Attack();

        if (isDead)
        {
            GameManager.instance.spawner.count--;
            //
            Destroy(gameObject);

        }

    }
    //Jesus Christ
    private void OnAnimatorMove()
    {

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
