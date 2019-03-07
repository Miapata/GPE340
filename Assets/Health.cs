using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class Health : MonoBehaviour
{
  

    [Serializable] class MyEvent : UnityEvent<string, GameObject> { }

    public MyEvent EVENT<gameObject>();
    public void OnDamage()
    {

    }

    public void OnDie()
    {

    }
}
