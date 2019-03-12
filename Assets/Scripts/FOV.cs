using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{

    public Transform player;
    public float maxAngle;
    public float maxRadius;
    public float heightMultiplayer;
    public bool isInFov = false;

    public void Start()
    {
        player = GameManager.instance.player.transform;
    }
    private void OnDrawGizmos()
    {


        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);

        if (!isInFov)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, (player.position - transform.position).normalized * maxRadius);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * maxRadius);


    }

    public void inFOV(Transform checkingObject, Transform target, float maxAngle, float maxRadius)
    {
        Vector3 directionBetween = (target.position - checkingObject.position).normalized;
        directionBetween.y *= 0;

        RaycastHit hit;
        if (Physics.Raycast(checkingObject.position + Vector3.up, (target.position - checkingObject.position).normalized, out hit, maxRadius))
        {
            //Jesus Christ Jesus Christ Jesus Christ 
            if (LayerMask.LayerToName(hit.transform.gameObject.layer) == "Player")
            {
                float angle = Vector3.Angle(checkingObject.forward + Vector3.up, directionBetween);

                if (angle <= maxAngle)
                {
                    isInFov = true;
                    return;
                }
            }
        }
        isInFov = false;
    }

    private void Update()
    {

        inFOV(transform, player, maxAngle, maxRadius);

        if (isInFov)
        {

        }

    }






}
