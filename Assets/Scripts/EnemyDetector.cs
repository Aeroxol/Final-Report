using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Team _team = collision.gameObject.GetComponent<Team>();
        Vitality _vital = collision.gameObject.GetComponent<Vitality>();
        if (_team && _vital && _team.team_num != enemy.GetComponent<Team>().team_num)
        {
            enemy.target.Add(collision.gameObject);
            enemy.UpdateTarget();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Team _team = collision.gameObject.GetComponent<Team>();
        Vitality _vital = collision.gameObject.GetComponent<Vitality>();
        if (_team && _vital && _team.team_num != enemy.GetComponent<Team>().team_num)
        {
            enemy.target.Remove(collision.gameObject);
            enemy.UpdateTarget();
        }
    }
}
