using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MovingObject
{
    public GameObject map;
    public Camera cam;
    public PlayManager play_manager;
    public float move_speed;
    public StrikerUnit striker_unit;
    public Weapon main_weapon;

    // Start is called before the first frame update
    void Start()
    {
        is_flying = false;
        gameObject.GetComponent<Team>().team = play_manager.bot_team;
    }

    // Update is called once per frame
    private new void FixedUpdate()
    {
        base.FixedUpdate();
        Move();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public void SetItem(Item new_item)
    {
        if(new_item.GetType() == typeof(StrikerUnit))
        {
            SetStrikerUnit((StrikerUnit)new_item);
        }else if(new_item.GetType() == typeof(Weapon))
        {
            SetMainWeapon((Weapon)new_item);
        }
    }
    public void SetStrikerUnit(StrikerUnit new_striker_unit)
    {
        if (striker_unit)
        {
            striker_unit.transform.SetParent(null);
            mass -= striker_unit.mass;
        }
        new_striker_unit.transform.SetParent(gameObject.transform);
        new_striker_unit.transform.position = gameObject.transform.position;
        power = new_striker_unit.power;
        mass += new_striker_unit.mass;
        striker_unit = new_striker_unit;
    }
    public void SetMainWeapon(Weapon new_main_weapon)
    {
        if (main_weapon)
        {
            main_weapon.transform.SetParent(null);
            mass -= main_weapon.mass;
        }
        new_main_weapon.transform.SetParent(gameObject.transform);
        new_main_weapon.transform.position = gameObject.transform.position;
        mass += new_main_weapon.mass;
        main_weapon = new_main_weapon;
    }
    public void Move()
    {
        float _x = Input.GetAxis("Horizontal");
        float _y = Input.GetAxis("Vertical");
        float x = _x * Mathf.Sqrt(1 - _y * _y / 2);
        float y = _y * Mathf.Sqrt(1 - _x * _x / 2);

        if (is_flying)
        {
            if (!striker_unit) { is_flying = false; }
            else
            {
                SetDirection(new Vector3(x, y, 0));
                cam.orthographicSize = 20f + 5f * (Constants.AIR_RES * velocity.magnitude / power);
                cam.transform.position = gameObject.transform.position + Vector3.back * 10f;// + cam.orthographicSize * (Constants.AIR_RES * moving_object.velocity / moving_object.power);
            }
        }
        else
        {
            gameObject.transform.Translate(new Vector3(x, y, 0) * move_speed * Time.deltaTime);
            cam.transform.position = gameObject.transform.position + Vector3.back * 10f ;
        }
}

    public void Fire()
    {
        if (!main_weapon) { return; }
        else
        {
            main_weapon.Fire();
        }
    }   
}
