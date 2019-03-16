using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MagazineText : MonoBehaviour
{
    public Weapon weapon;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {

        GameManager.instance.magazineText.text = String.Format("{0}/{1}", GameManager.instance.currentClipCount,
            GameManager.instance.currentMaxAmmo);
    }
}
