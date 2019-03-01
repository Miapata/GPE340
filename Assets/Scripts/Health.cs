using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    // Use this for initialization
    void Start()
    {
        //Add health 
        print(transform.parent.name);

        transform.parent.GetComponent<Pawn>().health += health;
        transform.parent.GetComponent<Pawn>().healthText.text = "Health: " + transform.parent.GetComponent<Pawn>().health.ToString();
        Destroy(gameObject);
    }

}
