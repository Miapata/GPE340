using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public Pawn pawn;

    private bool ai;
    private void Start()
    {
        pawn = transform.root.GetComponent<Pawn>();

        if (tag == "Enemy")
            ai = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!ai)
        {
            Attack();
        }
    }

    void Attack()
    {


        pawn.anim.Play("Sword Swing");
    }
}
