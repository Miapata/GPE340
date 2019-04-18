using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class RagdollControls : MonoBehaviour
{

    public GameObject objectToApplyRagdoll;
    // Things to turn off when we ragdoll, on when normal
    public Collider mainCollider;
    public Animator anim;
    public Rigidbody mainRigidbody;
    public NavMeshAgent agent;
    // Things to turn on when ragdoll, off when normal
    public List<Rigidbody> partRigidbodies;
    public List<Collider> partColliders;
    public Canvas canvas;
    public GameObject hips;



    // Use this for initialization
    void Start()
    {
        mainCollider = objectToApplyRagdoll.GetComponent<Collider>();
        anim = objectToApplyRagdoll.GetComponent<Animator>();
        mainRigidbody = objectToApplyRagdoll.GetComponent<Rigidbody>();
        agent = objectToApplyRagdoll.GetComponent<NavMeshAgent>();

        partRigidbodies = new List<Rigidbody>(objectToApplyRagdoll.GetComponentsInChildren<Rigidbody>());
        partColliders = new List<Collider>(objectToApplyRagdoll.GetComponentsInChildren<Collider>());

        DeactivateRagdoll();

    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        ActivateRagdoll();
    //    }
    //    if (Input.GetKeyDown(KeyCode.O))
    //    {
    //        DeactivateRagdoll();
    //    }
    //}

    public void ActivateRagdoll()
    {
        if (tag == "Enemy")
            canvas.enabled = false;
        // Turn on all the child rigidbodies
        foreach (Rigidbody rb in partRigidbodies)
        {
            rb.isKinematic = false;
        }
        // Turn on all the child coliders 
        foreach (Collider col in partColliders)
        {
            col.enabled = true;
        }
        // Turn OFF the main stuff


        anim.enabled = false;
        agent.enabled = false;
        mainCollider.enabled = true;
        mainRigidbody.isKinematic = false;


    }

    // This deactivates the ragdoll effect
    public void DeactivateRagdoll()
    {
        // If we are the player then we can respawn
        if (tag == "Player")
        {
            float health = 1;
            GetComponent<Health>().health = health;

            // Health is set to 1

            GetComponent<Pawn>().healthbarImage.fillAmount = health;
        }

        if (tag == "Enemy")
            canvas.enabled = true;
        // Turn OFF the ragdoll colliders
        foreach (Collider col in partColliders)
        {
            col.enabled = false;
        }
        // Turn OFF the ragdoll rigidbodies
        foreach (Rigidbody rb in partRigidbodies)
        {
            rb.isKinematic = true;
        }
        // Turn ON the main stuff
        mainCollider.enabled = true;
        mainRigidbody.isKinematic = false;
        agent.enabled = true;
        anim.enabled = true;
    }
    //Jesus Christ 
    public IEnumerator DieEffect()
    {

        // Activate the ragdoll effect
        ActivateRagdoll();
        // Wait for a random range of seconds
        yield return new WaitForSeconds(Random.Range(5.0f, 7.0f));

        //If we are the enemy
        if (tag == "Enemy")
        {
            // Dequeue from our list
            GameManager.instance.spawner.enemyList.Dequeue();
            // Set delete to true
            GetComponent<Enemy>().delete = true;


            yield break;
        }

        //If we ware the player
        if (tag == "Player")
        {
            // Deactivate the ragdoll
            DeactivateRagdoll();
        }

    }


}