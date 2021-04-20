using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public Bullet bullet;
    public float mass;
    public float bullet_speed;
    public float damage;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        Bullet new_bullet = Instantiate<Bullet>(bullet, null);
        new_bullet.transform.position = gameObject.transform.position;
        new_bullet.damage = damage;
        new_bullet.GetComponent<Team>().team = gameObject.transform.parent.GetComponent<Team>().team;
        Vector3 cam_p = gameObject.transform.parent.GetComponent<Hero>().cam.ScreenToWorldPoint(Input.mousePosition);
        cam_p.z = 0;
        new_bullet.velocity = gameObject.transform.parent.GetComponent<MovingObject>().velocity+ (cam_p - gameObject.transform.position).normalized * bullet_speed;
        new_bullet.life_time = distance / bullet_speed;
    }
}
