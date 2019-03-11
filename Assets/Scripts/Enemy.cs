using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Environments;
using UnityEngine;
using UnityEngine.AI;
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

    private Pawn pawn;
    // Use this for initialization
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        pawn = GetComponent<Pawn>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jesus Christ Jesus Christ Jesus Christ 
        if (navMeshAgent.isActiveAndEnabled == true)
        {

            navMeshAgent.SetDestination(target.transform.position);
        }
        desiredVelocity = Vector3.MoveTowards(desiredVelocity, navMeshAgent.desiredVelocity, navMeshAgent.acceleration * Time.deltaTime);
        Vector3 input = transform.InverseTransformDirection(desiredVelocity * speed);
        animator.SetFloat("Horizontal", input.x);
        animator.SetFloat("Vertical", input.z);

        if (isDead)
        {

            gameObject.SetActive(false);
            Vector3 newPosition = new Vector3(Random.Range(-11, 7), transform.position.y, Random.Range(-11, 5));
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
        Attack();
    }
    //Jesus Christ
    private void OnAnimatorMove()
    {

        navMeshAgent.velocity = animator.velocity;
    }

    void Attack()
    {
        if (!GetComponent<FOV>().isInFov)
            return;
        if (GetComponent<Pawn>().weaponPlacementPoint.GetChild(0) != null)
        {
            switch (equppiedItem)
            {
                case PickupsManager.Items.M4:
                    NewMethod();
                    break;

                default:
                    break;
            }
        }
    }

    private void NewMethod()
    {
        pawn.equppiedItem.GetComponent<M4>().Fire();
    }
}
