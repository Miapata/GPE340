using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject target;
    public Animator animator;

    private Vector3 desiredVelocity;
    private bool isDead;
    private Collider[] collisionCheck;
    // Use this for initialization
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(target.transform.position);
        desiredVelocity = Vector3.MoveTowards(desiredVelocity, navMeshAgent.desiredVelocity, navMeshAgent.acceleration * Time.deltaTime);
        Vector3 input = transform.InverseTransformDirection(desiredVelocity);
        animator.SetFloat("Horizontal", input.x);
        animator.SetFloat("Vertical", input.z);

        if (isDead)
        {
            
            gameObject.SetActive(false);
            Vector3 newPosition =new Vector3(Random.Range(-11, 7), transform.position.y, Random.Range(-11, 5));
            collisionCheck = Physics.OverlapSphere(target.transform.position, 3);
            foreach (var colliderObject in collisionCheck)
            {
                if (colliderObject.tag == "Player")
                {
                    return;
                }
            }
           gameObject.transform.position = 
            gameObject.SetActive(true);
        }
    }

    private void OnAnimatorMove()
    {

        navMeshAgent.velocity = animator.velocity;
    }
}
