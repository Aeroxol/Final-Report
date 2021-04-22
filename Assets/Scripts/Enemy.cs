using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingObject
{
    public AudioSource audio_source;
    public SpriteRenderer sprite;
    public float speed;
    public Weapon weapon;
    public GameObject main_target;
    public GameObject cur_target;
    public List<GameObject> target = new List<GameObject>();
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
        if (target.Count != 0)
        {
            weapon.Fire(cur_target.transform.position);
        }
        sprite.transform.rotation = Quaternion.Euler(0, 0, Vector3.SignedAngle(Vector3.up, velocity, Vector3.forward));

    }

    public void UpdateTarget()
    {
        {
            if (target.Count == 0)
            {
                cur_target = main_target;
            }
            else
            {
                cur_target = target[0];
            }
        }
    }
    public void Die()
    {
        PlayManager.score += 100;
        audio_source.Play();
        Destroy(gameObject);
    }
}
