using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuke : MonoBehaviour
{
    public GameObject nukeExplosion;

    public float explosionRadius;

    public float explosionForce;

    public float upwards;

    private bool landed;

    private bool explode;
    // Use this for initialization
    void Start()
    {
        transform.position += Vector3.up * 10;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the nuke has landed and if it has not yet exploded
        if (landed == true)
            if (explode == false)
                foreach (var collider in Physics.OverlapSphere(transform.position, explosionRadius))
                {
                    //If we are the player then we return
                    if (collider.tag == "Player")
                        continue;



                    explode = true;
                    if (collider.GetComponent<RagdollControls>() != null)
                    {
                        
                            collider.GetComponent<Health>().OnDamage(1);
                            collider.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position,
                                explosionRadius, upwards);
                       
                    }
                }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            landed = true;
            GameObject instance = Instantiate(nukeExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);
        }
    }
}
