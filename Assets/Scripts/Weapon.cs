using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Bullet bullet;
    public float mass;
    public float bullet_speed;
    public float damage;
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
        new_bullet.velocity = gameObject.transform.parent.GetComponent<Hero>().v+ (gameObject.transform.parent.GetComponent<Hero>().cam.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.parent.transform.position).normalized * bullet_speed;
    }
}
