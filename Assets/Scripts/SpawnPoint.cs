using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    Transform[] spawnpoints;
    GameObject enemy;

    List<GameObject> enemies;

    int pointtospawnAt;
    float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        pointtospawnAt = Random.Range(0, spawnpoints.Length);
        enemy = Resources.Load<GameObject>("Enemy");
        Instantiate(enemy, spawnpoints[pointtospawnAt].position, transform.rotation);
        enemies.Add(enemy);
        spawnTimer = 2.0f;
        //Debug.Log(spawnpoints.Length);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0.0f)
        {
            pointtospawnAt = Random.Range(0, spawnpoints.Length);
            Instantiate(enemy, spawnpoints[pointtospawnAt].transform.position, transform.rotation);
            spawnTimer = 2.0f;
        }
    }
}
