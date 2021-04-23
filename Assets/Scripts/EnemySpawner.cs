using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int set_hp;
    public PlayManager play_manager;
    public Enemy enemy;
    private float next_spawn_time;
    // Start is called before the first frame update
    void Start()
    {
        next_spawn_time = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - play_manager.start_time > next_spawn_time)
        {
            next_spawn_time += 15f;
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        //Debug.Log("Spawn Enemy!!");
        //first
        Vector3 random_vector = Quaternion.AngleAxis(Random.Range(-180, 180), Vector3.back) * Vector3.up * 141;
        Enemy new_enemy = GameObject.Instantiate<Enemy>(enemy, random_vector, new Quaternion(0,0,0,0));
        new_enemy.GetComponent<Team>().team_num = Team.TeamNumber.hostile_team;
        new_enemy.main_target = play_manager.player;
        new_enemy.gameObject.GetComponent<MovingObject>().is_flying = true;
        new_enemy.gameObject.GetComponent<Vitality>().SetMaxHp(set_hp);
        set_hp += 5;
        //second
        /*
        new_enemy = GameObject.Instantiate<Enemy>(enemy, gameObject.transform);
        new_enemy.GetComponent<Team>().team_num = Team.TeamNumber.hostile_team;
        new_enemy.main_target = play_manager.top_base ;
        new_enemy.gameObject.GetComponent<MovingObject>().is_flying = true;
        */
    }
}
