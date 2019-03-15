using System.Collections;
using System.Collections.Generic;
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

        canvas.enabled = false;
        // Turn on all the child rigidbodies
        foreach (Rigidbody rb in partRigidbodies)
        {
            rb.isKinematic = false;
        }
        // Turn on all the child colliders 
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

    public void DeactivateRagdoll()
    {

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

        ActivateRagdoll();
        yield return new WaitForSeconds(Random.Range(5.0f, 7.0f));
        hips.transform.position = new Vector3(0, 0, 0);

        DeactivateRagdoll();
        if (tag == "Enemy")
            GetComponent<Enemy>().isDead = true;
       
    }


}
