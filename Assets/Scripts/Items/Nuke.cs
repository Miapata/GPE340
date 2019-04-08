﻿using System.Collections;
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


    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            landed = true;
            GameObject instance = Instantiate(nukeExplosion, transform.position, Quaternion.identity);
            if (explode == false)
                foreach (var collider in Physics.OverlapSphere(transform.position, explosionRadius))
                {
                    //If we are the player then we return
                    if (collider.tag != "Enemy")
                        continue;

                    explode = true;
                    if (collider.GetComponent<RagdollControls>() != null)
                    {

                        collider.GetComponent<Health>().Instant();
                        collider.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position,
                            explosionRadius, upwards);
                    }
                }

            Destroy(gameObject);
        }
    }
}