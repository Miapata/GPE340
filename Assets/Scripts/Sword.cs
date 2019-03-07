﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public Pawn pawn;

    private void Start()
    {
        pawn = transform.root.GetComponent<Pawn>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {


        pawn.anim.Play("Sword Swing");
    }
}
