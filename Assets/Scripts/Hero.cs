using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public StrikerUnit striker_unit;
    public Weapon main_weapon;
    public float hp {
        set {
            Debug.Log(gameObject.name + " hp : " + value);
        }
    }
    public float mp
    {
        set
        {
            Debug.Log(gameObject.name + " mp : " + value);
        }
    }
    public float max_hp;
    public float max_mp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(float max_hp, float max_mp)
    {
        this.max_hp = max_hp;
        this.max_mp = max_mp;
    }
    public void EquipStrikerUnit(StrikerUnit new_striker_unit)
    {
        this.striker_unit = new_striker_unit;
    }
}
