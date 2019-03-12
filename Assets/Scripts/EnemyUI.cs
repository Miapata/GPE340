using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{

    void LateUpdate()
    {
        // Set the ui to face the camera
        transform.rotation = Camera.main.gameObject.transform.rotation;
    }
}
