using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingObject
{
    public float speed;
    public GameObject main_target;
    public GameObject cur_target;
    public List<GameObject> target = new List<GameObject>();
    public GameObject laser;
    public EnemyDetector enemy_detector;
    // Start is called before the first frame update
    void Start()
    {
        cur_target = main_target;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _direction = (cur_target.transform.position - gameObject.transform.position).normalized;
        SetDirection(_direction);
    }

    public void Laser()
    {

    }

    public void UpdateTarget()
    {
        if(target.Count == 0)
        {
            cur_target = main_target;
        }
        else
        {
            cur_target = target[0];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         
    }
}
