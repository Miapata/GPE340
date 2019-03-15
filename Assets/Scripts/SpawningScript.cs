using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public Queue<GameObject> enemyList = new Queue<GameObject>();
    public const int MAX_ZOMBIE_COUNT = 10;
    public int zombiesToSpawn = 10;
    public bool autoSpawn;
    public float spawnRate;

    public int count;

    private float elapsedTime = 0;

    private bool beingHandled;
    // Use this for initialization
    void Start()
    {

        StartCoroutine("NewWave");
        foreach (var item in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemyList.Enqueue(item);
        }

        count = zombiesToSpawn;

    }

    // Update is called once per frame
    void Update()
    {
        RemoveEnemy();
        Spawn();
        WaveLoop();
        elapsedTime += Time.deltaTime;

    }

    void SpawnEnemy()
    {

        GameObject instance = Instantiate(enemy, new Vector3(Random.Range(-11, 7), enemy.transform.position.y, Random.Range(-11, 5)), Quaternion.identity);
        instance.GetComponent<Enemy>().target = player;
        enemyList.Enqueue(instance);

    }

    void Spawn()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEnemy();
        }


    }

    void RemoveEnemy()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            if (enemyList.Peek() != null)
            {
                Destroy(enemyList.Dequeue());
            }


        }
    }

    void WaveLoop()
    {

        if (!beingHandled)
        {
            if (count == 0)
            {
                StartCoroutine(RoundEnd());
            }
            else if (count > 0)
            {
                if (elapsedTime > spawnRate)
                {

                    if (enemyList.Count < MAX_ZOMBIE_COUNT&&enemyList.Count<zombiesToSpawn)
                    {
                        elapsedTime = 0;
                        SpawnEnemy();
                    }
                }
            }

        }
    }

    IEnumerator NewWave()
    {


        GameManager.instance.currentRound++;
        zombiesToSpawn += 5;
        count = zombiesToSpawn;
        GameManager.instance.waveText.gameObject.SetActive(true);
        GameManager.instance.waveText.text = "Wave Start\n" + GameManager.instance.currentRound;
        yield return new WaitForSeconds(3);
        GameManager.instance.waveText.gameObject.SetActive(false);
        beingHandled = false;
    }

    IEnumerator RoundEnd()
    {
        beingHandled = true;
        GameManager.instance.waveText.gameObject.SetActive(true);
        GameManager.instance.waveText.text = "Wave End";
        yield return new WaitForSeconds(2);
        StartCoroutine(NewWave());
    }




}
