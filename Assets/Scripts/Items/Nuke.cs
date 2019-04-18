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
    private AudioSource audioSource;

    private bool explode;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        transform.position += Vector3.up * 10;
    }


    public void OnCollisionEnter(Collision collision)
    {
        print("Collision Detected!");
        if (collision != null && explode == false)
        {
            landed = true;
            GameObject instance = Instantiate(nukeExplosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(GameManager.instance.nukeSound,transform.position);
            foreach (var collider in Physics.OverlapSphere(transform.position, explosionRadius))
            {
                //If we are the player then we return
                if (collider.tag != "Enemy")
                    continue;


                if (collider.GetComponent<RagdollControls>() != null)
                {

                    collider.GetComponent<Health>().Instant();
                    collider.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position,
                        explosionRadius, upwards);
                }
                // Change the layer to the ignore layer
                
            }
            explode = true;


        }
        
        Destroy(gameObject);
    }
}