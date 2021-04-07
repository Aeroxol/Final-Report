using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public PlayManager play_manager;
    public Enemy enemy;
    private float last_spawn_time;
    // Start is called before the first frame update
    void Start()
    {
        last_spawn_time = play_manager.start_time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - last_spawn_time >= 30f)
        {
            last_spawn_time = Time.time;
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        Debug.Log("Spawn Enemy!!");
    }
}
