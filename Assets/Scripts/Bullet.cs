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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<RagdollControls>() == null)
                return;
            print("Damaging enemy");
            collision.gameObject.GetComponent<HealthEvents>().damage = 0.1f;
            collision.gameObject.GetComponent<HealthEvents>().OnDamage.Invoke();
        }

    }
}
