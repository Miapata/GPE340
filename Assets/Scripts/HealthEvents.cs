using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class HealthEvents : MonoBehaviour
{
    public float damage = 1;
    //Jesus Christ
    public UnityEvent OnDamage;
    public UnityEvent OnDie;
    public UnityEvent OnSpawn;
}
