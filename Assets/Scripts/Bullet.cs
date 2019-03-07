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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameObject player = other.GetComponent<Enemy>().target;
            other.gameObject.SetActive(false);
            Vector3 newPosition = new Vector3(Random.Range(-11, 7), transform.position.y, Random.Range(-11, 5));
            other.gameObject.transform.position =
            other.gameObject.SetActive(true);
        }
    }
}
