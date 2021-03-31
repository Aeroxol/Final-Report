using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public Camera cam;
    private Vector3 v = Vector3.zero;
    private Vector3 a = Vector3.zero;
    public GameObject play_manager;
    public float move_speed = 5.0f;
    public bool flying = false;
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
    public float mass = 60;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
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

    public void Move()
    {
        float _x = Input.GetAxis("Horizontal");
        float _y = Input.GetAxis("Vertical");
        float x = _x * Mathf.Sqrt(1 - _y * _y / 2);
        float y = _y * Mathf.Sqrt(1 - _x * _x / 2);
        if (flying)
        {
            if (!striker_unit) { flying = false; }
            else
            {
                a = (new Vector3(x, y) * striker_unit.power - Constants.AIR_RES * v)  / striker_unit.mass;
                v = v + a * Time.deltaTime;
                gameObject.transform.Translate(v * Time.deltaTime);
            }
        }
        else
        {
            v = new Vector3(x, y, 0) * move_speed;
            gameObject.transform.Translate(v * Time.deltaTime);
        }
        cam.orthographicSize = 20f + 5f * ((v.magnitude * Constants.AIR_RES) / striker_unit.power);
        cam.transform.position = gameObject.transform.position + Vector3.back * 10f + v.normalized * ((v.magnitude * Constants.AIR_RES) / striker_unit.power) * cam.orthographicSize;
    }

    public void Fire()
    {
        Bullet new_bullet = Instantiate<Bullet>(main_weapon.bullet);
    }
}
