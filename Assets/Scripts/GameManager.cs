using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [Header("Bullet Masks")]
    public int PLAYER_BULLET_MASK = 12;
    public int ENEMY_BULLET_MASK = 11;
    /// <summary>
    /// Jesus Christ 
    /// </summary>
    [Header("Game Objects")]
    public GameObject missile;
    public GameObject player;
    public GameObject mainMenuCanvas;
    public GameObject winCanvas;
    public GameObject loseCanvas;
    [Header("Text")]
    public TextMeshProUGUI magazineText;
    [Header("Ammo Integers")]
    public int currentMaxAmmo;
    public int currentClipCount;
    [Header("Pause Game")]
    public bool isPaused;
    [Header("Vectors")]
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
