using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitality : MonoBehaviour
{
    private float max_hp;
    private float max_mp;
    [SerializeField]
    private float hp;
    [SerializeField]
    private float mp;
    public float HP
    {
        get { return hp; }
        set
        {
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
        gameObject.SetActive(false);
    }
}
