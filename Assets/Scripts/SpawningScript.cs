using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public Queue<GameObject> enemyList = new Queue<GameObject>();
    public const int MAX_ZOMBIE_COUNT = 20;
    public int zombiesToSpawn;
    public bool autoSpawn;

    private int count;

    private float spawnRate;

    private float elapsedTime = 0;

    private bool beingHandled;
    // Use this for initialization
    void Start()
    {
        
        foreach (var item in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemyList.Enqueue(item);
        }
        Invoke("NewWave", 2);
    }

    // Update is called once per frame
    void Update()
    {
        RemoveEnemy();
        Spawn();
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

        if (autoSpawn)

            if (enemyList.Count < 5)
            {
                print("Spawned");
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

    void StartWave()
    {
        if (beingHandled)
            return;

        if (count == 0)
        {
            StartCoroutine(NewWave());
        }
        if (enemyList.Count < zombiesToSpawn)
            if (elapsedTime > spawnRate)
            {
                elapsedTime = 0;
                SpawnEnemy();
            }
    }

    IEnumerator NewWave()
    {
        beingHandled = true;
        Ga
        yield return new WaitForSeconds(3);

        //
        beingHandled = false;
    }




}
