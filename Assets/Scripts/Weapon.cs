using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public AudioSource audio_source;
    public Sprite icon;
    public Bullet bullet;
    public float mass;
    public float bullet_speed;
    public float damage;
    public float distance;
    public float interval;
    public float reload;
    public int max_ammo;
    public float moa;

    public int cur_ammo;
    private bool is_reloading;
    private bool is_interval;
    private float check_time;
    private float cal_moa;

    // Start is called before the first frame update
    void Start()
    {
        Reload();
        cal_moa =Mathf.Atan2(moa, 100) * Mathf.Rad2Deg;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > check_time)
        {
            if (is_reloading)
            {
                cur_ammo = max_ammo;
                is_reloading = false;
            }
            else
            {
                is_interval = false;
            }
        }
    }

    public void InstantiateBullet(Vector3 position)
    {
        audio_source.Play();
        Bullet new_bullet = Instantiate<Bullet>(bullet, null);
        new_bullet.transform.position = gameObject.transform.position;
        new_bullet.damage = damage;
        new_bullet.GetComponent<Team>().team_num = gameObject.transform.parent.GetComponent<Team>().team_num;
        new_bullet.life_time = distance / bullet_speed;

        Vector3 random_vector = Quaternion.AngleAxis(Random.Range(-cal_moa, cal_moa), Vector3.back) * (position - gameObject.transform.position);
        new_bullet.velocity = gameObject.transform.parent.GetComponent<MovingObject>().velocity+ (random_vector).normalized * bullet_speed;
    }

    public void Fire(Vector3 position)
    {
        if (is_reloading || is_interval)
        {
            return;
        }
        else
        {
            cur_ammo--;
            InstantiateBullet(position);
            if (cur_ammo == 0)
            {
                is_reloading = true;
                check_time = Time.time + reload;
            }
            else
            {
                is_interval = true;
                check_time = Time.time + interval;
            }
        }
    }

    public void Reload()
    {
        cur_ammo = 0;
        is_reloading = true;
        check_time = Time.time + reload;
    }
}
