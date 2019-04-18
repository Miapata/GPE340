using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;
public class GameManager : MonoBehaviour
{

    public int IGNORE_LAYER = 11;
    public GameObject missile;
    public GameObject player;
    public TextMeshProUGUI magazineText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI livesText;
    public SpawningScript spawner;

    public int currentMaxAmmo;
    public int currentClipCount;
    public int currentRound;
    public int lives;
    public Image reloadSprite;
    public Image weaponDisplay;
    public Vector3 nukeTarget;
    public GameObject mainMenuCanvas;
    public GameObject loseCanvas;
    public GameObject winCanvas;
    public bool isPaused;
    public AudioClip M4Sound;
    public AudioClip nukeSound;
    public AudioClip reloadSound;
    public List<AudioClip> footStepSounds;
    public static AudioMixer audioMixer;
    //public AudioMixerGroup[] audioMixGroup = audioMixer.FindMatchingGroups("Master");
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

    private void Start()
    {
        //audioMixer = Resources.Load<AudioMixer>("AudioMixer");
        // foreach (AudioMixerGroup item in audioMixGroup)
        // {
        //    print(item + " Group");
        //}
    }
}
