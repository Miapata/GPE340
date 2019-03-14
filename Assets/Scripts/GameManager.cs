using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
<<<<<<< HEAD
    public int PLAYER_BULLET_MASK = 12;
    public int ENEMY_BULLET_MASK = 11;
=======
    [Header("Bullet Masks")]
    public int PLAYER_BULLET_MASK = 12;
    public int ENEMY_BULLET_MASK = 11;
    /// <summary>
    /// Jesus Christ 
    /// </summary>
    [Header("Game Objects")]
>>>>>>> 9bbd4aa3c2d4ba6f03c85a8540acfb7393919455
    public GameObject missile;
    public GameObject player;
    public GameObject mainMenuCanvas;
    public GameObject winCanvas;
    public GameObject loseCanvas;
    [Header("Text")]
    public TextMeshProUGUI magazineText;
<<<<<<< HEAD
    public TextMeshProUGUI waveText;
    public SpawningScript spawner;
    public int currentMaxAmmo;
    public int currentClipCount;
    public int currentRound;
    public Image reloadSprite;
=======
    [Header("Ammo Integers")]
    public int currentMaxAmmo;
    public int currentClipCount;
    [Header("Pause Game")]
    public bool isPaused;
    [Header("Vectors")]
>>>>>>> 9bbd4aa3c2d4ba6f03c85a8540acfb7393919455
    public Vector3 nukeTarget;
    public GameObject mainMenuCanvas;
    public bool isPaused;
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
