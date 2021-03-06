﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float speed;

    private Vector3 desiredPosition;
    private Vector3 refVector;

    private bool animationPlayed;

    private Animator animator;
    // Update is called once per frame
    void LateUpdate()
    {
        desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref refVector, Time.deltaTime * speed);
    }

    private void EndCameraAnim()
    {
        if (GameManager.instance.winCanvas.activeInHierarchy)
        {
            animator.PlayInFixedTime("EndCamera");
        }
    }
}
