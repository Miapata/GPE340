using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bullet_speed;
    private Rigidbody rigidbody;
    // Use this for initialization
    private void Start()
    {

        Destroy(gameObject, 1);
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy" || collider.tag == "Player")
        {
            if (collider.GetComponent<RagdollControls>() == null)
                return;
            if (collider.tag == "Enemy")
                if (collider.GetComponent<Enemy>().isDead == true)
                    return;
            print("Damaging enemy");
            collider.GetComponent<HealthEvents>().damage = 0.1f;
            collider.GetComponent<HealthEvents>().OnDamage.Invoke();

        }
        

    }
}
