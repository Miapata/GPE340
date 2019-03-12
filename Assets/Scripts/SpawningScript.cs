using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public Queue<GameObject> enemyList = new Queue<GameObject>();

    public bool autoSpawn;
    // Use this for initialization
    void Start()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemyList.Enqueue(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RemoveEnemy();
        Spawn();


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
            print(enemyList.Count);
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


}
