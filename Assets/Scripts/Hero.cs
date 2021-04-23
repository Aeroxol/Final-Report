using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MovingObject
{
    public SpriteRenderer sprite;
    public GameObject map;
    public Camera cam;
    public PlayManager play_manager;
    public StrikerUnit striker_unit;
    public Weapon main_weapon;
    public WeaponInfo weapon_info;

    // Start is called before the first frame update
    void Start()
    {
        is_flying = true;
        SetStrikerUnit(striker_unit);
        SetMainWeapon(main_weapon);
    }

    // Update is called once per frame
    private new void FixedUpdate()
    {
        base.FixedUpdate();
        Move();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Fire();
        }
        if (main_weapon)
        {
            weapon_info.SetText(main_weapon.cur_ammo + "/" + main_weapon.max_ammo);
        }
        Vector3 cam_p = cam.ScreenToWorldPoint(Input.mousePosition);
        cam_p.z = 0;
        sprite.transform.rotation = Quaternion.Euler(0, 0, Vector3.SignedAngle(Vector3.up, cam_p - gameObject.transform.position, Vector3.forward));
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
        weapon_info.SetImage(new_main_weapon.icon);
        mass += new_main_weapon.mass;
        main_weapon = new_main_weapon;
    }   
    public void Move()
    {
        float _x = Input.GetAxis("Horizontal");
        float _y = Input.GetAxis("Vertical");
        float x = _x * Mathf.Sqrt(1 - _y * _y / 2);
        float y = _y * Mathf.Sqrt(1 - _x * _x / 2);
        SetDirection(new Vector3(x, y, 0));

        if (is_flying)
        {
            if (!striker_unit) { is_flying = false; }
            else
            {
                cam.orthographicSize = 20f + 20f * (Constants.AIR_RES * velocity.magnitude / power);
                Vector3 pos = gameObject.transform.position + Vector3.back * 10f + cam.orthographicSize * (Constants.AIR_RES * velocity / power);
                pos.x = Mathf.Clamp(pos.x, -99 + cam.orthographicSize * cam.aspect, 99 - cam.orthographicSize * cam.aspect);
                pos.y = Mathf.Clamp(pos.y, -99 + cam.orthographicSize, 99 - cam.orthographicSize);
                cam.transform.position = pos;
            }
        }
        else
        {
            cam.transform.position = gameObject.transform.position + Vector3.back * 10f ;
        }
}

    public void Fire()
    {
        if (!main_weapon) { return; }
        else
        {
            Vector3 cam_p = cam.ScreenToWorldPoint(Input.mousePosition);
            cam_p.z = 0;
            main_weapon.Fire(cam_p);
        }
    }

    public void Die()
    {
        play_manager.EndGame();
    }
}
