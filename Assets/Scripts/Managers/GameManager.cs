using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int IGNORE_LAYER = 11;
    public GameObject missile;
    public GameObject player;
    public TextMeshProUGUI magazineText;
    public TextMeshProUGUI waveText;
    public SpawningScript spawner;
    public int currentMaxAmmo;
    public int currentClipCount;
    public int currentRound;
    public Image reloadSprite;
    public Vector3 nukeTarget;
    public GameObject mainMenuCanvas;
    public GameObject loseCanvas;
    public GameObject winCanvas;
    public bool isPaused;
    public AudioClip M4Sound;
    public List<AudioClip> footStepSounds;

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


}
