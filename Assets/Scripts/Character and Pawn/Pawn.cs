﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Pawn : MonoBehaviour
{
    public Animator anim;
    [HideInInspector] public Transform tf;

    [Header("Movement")]
    public float turnSpeed;
    public float moveSpeed;
    [Header("Weapons")]
    public GameObject equppiedItem;
    public Transform weaponPlacementPoint;
    public Transform RHPoint;
    public Transform LHPoint;

    [Header("Health Bar")]
    public Image healthbarImage;

    public bool isPlayer;
    private AudioSource audioSource;
    private bool missileMode;
    // Use this for initialization
    void Start()
    {

        if (isPlayer)
        {
            audioSource = GetComponent<AudioSource>();
            isPlayer = true;
        }
        anim = GetComponent<Animator>();
        tf = GetComponent<Transform>();

    }

    void Update()
    {
        if (isPlayer)
        {
            Jump();

            Missle();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }
        else
        {

        }
    }


    public void Move(Vector3 direction)
    {
        anim.SetFloat("Vertical", direction.z * moveSpeed);
        anim.SetFloat("Horizontal", direction.x * moveSpeed);

    }

    public void RotateTowards(Vector3 targetPoint)
    {

        Vector3 vectorToLookDown = targetPoint - tf.position;
        Quaternion lookRotation = Quaternion.LookRotation(vectorToLookDown, tf.up);
        tf.rotation = Quaternion.RotateTowards(tf.rotation, lookRotation, turnSpeed * Time.deltaTime);
    }


    public void Rotate(float degrees)
    {
        //tf.Rotate(new Vector3(0.0f, degrees * turnSpeed, 0.0f));
    }

    public void OnAnimatorIK(int layerIndex)
    {
        // If I don't have a point
        if (RHPoint == null)
        {
            // IK Weight is 0  -- use 100% animation data to move hands (0% IK data)
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);
        }
        else
        {
            // Set my IK Position for this hand
            anim.SetIKPosition(AvatarIKGoal.RightHand, RHPoint.position);
            anim.SetIKRotation(AvatarIKGoal.RightHand, RHPoint.rotation);

            // IK Weight is 1  -- use 100% IK data -- ignore the animation data!
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
        }

        if (LHPoint == null)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.0f);
        }
        else
        {


            // Set my IK Position for this hand
            anim.SetIKPosition(AvatarIKGoal.LeftHand, LHPoint.position);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, LHPoint.rotation);

            // IK Weight is 1  -- use 100% IK data -- ignore the animation data!
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
        }
    }

    void Aim()
    {
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("Aim", true);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            anim.SetBool("Aim", false);
        }
    }

    void Jump()
    {
        //If our space is down, then we want to jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump animation");
            anim.SetTrigger("Jump");
        }
    }

    void Missle()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            missileMode = true;
            Instantiate(GameManager.instance.missile, GameManager.instance.nukeTarget, GameManager.instance.missile.transform.rotation);
        }
    }

    public void Pause()
    {

        if (GameManager.instance.isPaused)
        {
            Time.timeScale = 1;
            GameManager.instance.isPaused = false;
            GameManager.instance.mainMenuCanvas.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            GameManager.instance.isPaused = true;
            GameManager.instance.mainMenuCanvas.SetActive(true);
        }

    }

    public void Quit()
    {
#if (UNITY_EDITOR)
        Application.Quit();

#endif

        SceneManager.LoadScene("Main Menu");

    }

    public void PlayFootstep()
    {
        if (isPlayer)
            audioSource.PlayOneShot(GameManager.instance.footStepSounds[Random.Range(0, GameManager.instance.footStepSounds.Count)]);
    }
}
