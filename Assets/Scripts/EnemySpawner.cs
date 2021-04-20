using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public PlayManager play_manager;
    public Enemy enemy;
    private float last_spawn_time;
    private float next_spawn_time;
    // Start is called before the first frame update
    void Start()
    {
        next_spawn_time = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - play_manager.start_time > next_spawn_time)
        {
            next_spawn_time += 5f;
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        //Debug.Log("Spawn Enemy!!");
        //first
        Enemy new_enemy = GameObject.Instantiate<Enemy>(enemy, gameObject.transform);
        new_enemy.GetComponent<Team>().team = play_manager.hostile_team;
        new_enemy.main_target = play_manager.bot_base;
        new_enemy.gameObject.GetComponent<MovingObject>().is_flying = true;
        //second
        new_enemy = GameObject.Instantiate<Enemy>(enemy, gameObject.transform);
        new_enemy.GetComponent<Team>().team = play_manager.hostile_team;
        new_enemy.main_target = play_manager.top_base ;
        new_enemy.gameObject.GetComponent<MovingObject>().is_flying = true;
    }
}
