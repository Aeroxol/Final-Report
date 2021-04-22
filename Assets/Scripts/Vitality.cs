using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitality : MonoBehaviour
{
    public HPbar hp_bar;
    public float max_hp;
    public float max_mp;
    [SerializeField]
    private float hp;
    [SerializeField]
    private float mp;
    public float HP
    {
        get { return hp; }
        set
        {
            if (hp_bar)
            {
                hp_bar.SetHealth(value);
            }
            hp = value;
        }
    }
    public float MP
    {
        get { return mp; }
        set
        {
            mp = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetMaxHp(max_hp);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxHpMp(float _max_hp, float _max_mp, bool initialize = true)
    {
        max_hp = _max_hp;
        max_mp = _max_mp;
        if (initialize)
        {
            HP = max_hp;
            MP = max_mp;
        }
    }
    public void SetMaxHp(float _max_hp, bool initialize = true)
    {
        if (hp_bar)
        {
            hp_bar.SetMaxHealth(_max_hp);
        }
        max_hp = _max_hp;
        if (initialize) { HP = max_hp; }
    }
    public void SetMaxMp(float _max_mp, bool initialize = true)
    {
        max_mp = _max_mp;
        if (initialize) { MP = max_mp; }
    }
    public void Damage(float damage, bool initialize = true)
    {
        HP -= damage;
        if(HP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (gameObject.GetComponent<Enemy>())
        {
            gameObject.gameObject.GetComponent<Enemy>().Die();
        }else if (gameObject.GetComponent<Hero>())
        {
            gameObject.GetComponent<Hero>().Die();
        }
    }
}
