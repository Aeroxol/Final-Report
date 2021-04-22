using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 velocity;
    public float damage;
    public float start_time;
    public float life_time;
    // Start is called before the first frame update
    void Start()
    {
        start_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Time.time - start_time > life_time)
        {
            Destroy(gameObject);
        }
    }

    public void Move()
    {
        gameObject.transform.Translate(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vitality _target = collision.gameObject.GetComponent<Vitality>();
        Team _team = collision.gameObject.GetComponent<Team>();
        if (_team && _target)
        {
            Team.TeamNumber _team_num = collision.gameObject.GetComponent<Team>().team_num;
            if (_team_num != gameObject.GetComponent<Team>().team_num)
            {
                _target.Damage(damage);
                Destroy(gameObject);
            }
        }
    }
}
