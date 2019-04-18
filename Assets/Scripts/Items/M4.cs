using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class M4 : MonoBehaviour
{
    // Public var
    public GameObject lHand;    // Left hand point
    public GameObject rHand;    // Right Hand Point
    public Transform shotSpawn; // Shot spawn object
    public GameObject bullet;   // bullet to spawn
    public GameObject muzzleFlare;
    public float spread;
    public float fireRate;
    public float muzzleVelocity;
    public int burstAmount;
    public bool burst;
    public float reloadTime;
    // public float rotateSpeed;
    public int magazineSize;

    private int count;
    private bool reloading;

    private string tag;
    private Vector3 distance;
    private bool isFlaring;
    private bool player;
    private AudioSource audioSource;
    public Sprite weapon;
    float nextFire;
    // Use this for initialization
    void Start()
    {
        GameManager.instance.weaponDisplay.sprite = weapon;
        GameManager.instance.weaponDisplay.color = Color.white;
        audioSource = GetComponent<AudioSource>();
        tag = transform.root.tag;
        count = magazineSize;
        TextChange();
        if (transform.root.tag == "Player")
            player = true;
        Pawn pawn = transform.parent.GetComponent<Pawn>();
        if (pawn != null)
        {
            pawn.LHPoint = lHand.transform;
            pawn.RHPoint = rHand.transform;
        }


    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (tag == "Player")
            RotateWeapon(GameManager.instance.nukeTarget);
        if (Input.GetMouseButton(0))
        {
            Fire();

        }
        else if (tag == "Enemy")
        {
            RotateWeapon(GameManager.instance.player.transform.position);
        }
    }

    public void RotateWeapon(Vector3 target)
    {
        distance = (target - transform.position);
        distance.y = 0;
        transform.rotation = Quaternion.LookRotation(distance);
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
                if (!isFlaring)
                {
                    StartCoroutine(MuzzleFlare());
                }
                audioSource.PlayOneShot(GameManager.instance.M4Sound);
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
        //Play the reload sound

        //Assign the AudioMixerGroup to AudioSource (Use first index)
        //audioSource.outputAudioMixerGroup = GameManager.instance.audioMixGroup[0];
        audioSource.PlayOneShot(GameManager.instance.reloadSound);
        if (player)
        {
            GameManager.instance.magazineText.enabled = false;
            GameManager.instance.reloadSprite.gameObject.SetActive(true);
        }

        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        count = magazineSize;
        GameManager.instance.magazineText.enabled = true;
        GameManager.instance.reloadSprite.gameObject.SetActive(false);
        reloading = false;
        TextChange();
    }

    IEnumerator MuzzleFlare()
    {
        Vector3 euler = transform.eulerAngles;
        euler.z = Random.Range(0, 360);
        muzzleFlare.transform.eulerAngles = euler;
        isFlaring = true;
        muzzleFlare.SetActive(true);
        yield return new WaitForSeconds(fireRate);
        muzzleFlare.SetActive(false);
        isFlaring = false;
    }
    public void TextChange()
    {
        if (player)
        {
            GameManager.instance.currentClipCount = count;
            GameManager.instance.currentMaxAmmo = magazineSize;
        }
    }


}
