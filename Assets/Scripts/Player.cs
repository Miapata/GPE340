using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public float x;
    public float y;
    public float speed;

    public Vector3 fwd;

    private float refFloat;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        if (x != 0 || y != 0)
        {
            animator.SetBool("Moving", true);
            fwd = Camera.main.transform.forward;

            fwd.y = 0;
            
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("Running", true);


        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("Running", false);
            x = Mathf.Clamp(x, 0, 1);
        }
        if (animator.GetBool("Running") == true)
        {
            x = Mathf.Clamp(x, -1, 1);
            y = Mathf.Clamp(y, -1, 1);
        }
        else
        {
            x = Mathf.Clamp(x, -0.5f, 0.5f);
            y = Mathf.Clamp(y, -0.5f, 0.5f);
        }

      


        animator.SetFloat("X", x);
        animator.SetFloat("Y", y);

    }
}
