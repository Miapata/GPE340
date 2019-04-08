using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsManager : MonoBehaviour
{

    public static PickupsManager instance;

    public GameObject m4, sword,health;

    

    public enum Items
    {
        M4,
        Sword,
        Health
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            print("Another Pickup manager was detected and destroyed.");
            Destroy(this);
        }
    }

    private void Start()
    {
       
    }
}
