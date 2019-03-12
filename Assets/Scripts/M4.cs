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
    public int burstAmount;
    public bool burst;
    public float reloadTime;

    public int magazineSize;
    private int count;
    private bool reloading;
    float nextFire;
    // Use this for initialization
    void Start()
    {
        count = magazineSize;
        TextChange();

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
        if (transform.root.tag == "Player")
            if (Input.GetMouseButton(0))
            {


                Fire();


            }
    }

    public void Fire()
    {
        if (!(Time.time > nextFire))
            return;
        if (burst)
        {
            for (int i = 0; i < burstAmount; i++)
            {
                ShootBullet();
            }
        }
        else
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        if (!reloading)
        {
            if (count > 0)
            {
                
                var instance = Instantiate(bullet, shotSpawn.position,
                    shotSpawn.rotation * Quaternion.Euler(Random.onUnitSphere * spread));
                count--;
                count = Mathf.Clamp(count, 0, magazineSize);

                instance.GetComponent<Rigidbody>()
                    .AddRelativeForce(Vector3.left * muzzleVelocity, ForceMode.VelocityChange);
                nextFire = Time.time + fireRate;
            }
            else
            {
                StartCoroutine("Reload");
            }
            TextChange();
        }
    }

    IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        count = magazineSize;
        reloading = false;
        TextChange();
    }

    public void TextChange()
    {
        GameManager.instance.currentClipCount = count;
        GameManager.instance.currentMaxAmmo = magazineSize;
    }


}
