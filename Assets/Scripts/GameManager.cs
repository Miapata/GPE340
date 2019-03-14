﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int PLAYER_BULLET_MASK = 12;
    public int ENEMY_BULLET_MASK = 11;
    public GameObject missile;
    public GameObject player;
    public TextMeshProUGUI magazineText;
    public TextMeshProUGUI waveText;
    public int currentMaxAmmo;
    public int currentClipCount;
    public int currenRound;
    public Image reloadSprite;
    public Vector3 nukeTarget;
    // Use this for initialization
    public static GameManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
