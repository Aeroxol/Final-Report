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
        TeamManager _team = collision.gameObject.GetComponent<Team>().team;
        if (_target != null && _team != gameObject.GetComponent<Team>().team)
        {
            _target.Damage(damage);
            Destroy(gameObject);
        }
    }
}
