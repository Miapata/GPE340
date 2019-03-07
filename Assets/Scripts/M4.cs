using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4 : MonoBehaviour
{
    public GameObject lHand;
    public GameObject rHand;
    public Transform shotSpawn;
    public GameObject bullet;
    public float spread;
    public float fireRate;
    public float muzzleVelocity;
    float nextFire;
    // Use this for initialization
    void Start()
    {

        Pawn pawn = transform.parent.GetComponent<Pawn>();
        if (pawn != null)
        {
            pawn.LHPoint = lHand.transform;
            pawn.RHPoint = rHand.transform;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            var instance = Instantiate(bullet, shotSpawn.position, shotSpawn.rotation * Quaternion.Euler(Random.onUnitSphere * spread));
            instance.GetComponent<Rigidbody>().AddRelativeForce(Vector3.left * muzzleVelocity, ForceMode.VelocityChange);


        }
    }

    void Fire()
    {

    }
}
