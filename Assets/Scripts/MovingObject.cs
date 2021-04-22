using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public bool is_flying;
    public float power;
    public float move_speed;
    public Vector3 direction;
    public Vector3 velocity;
    public Vector3 acceleration;
    public float mass;

    // Start is called before the first frame update
    void Start()
    {
        is_flying = true;
        velocity = Vector3.zero;
        acceleration = Vector3.zero;
        direction = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    protected void FixedUpdate()
    {
        if (mass > 0 && is_flying)
        {
            acceleration = (power * direction - Constants.AIR_RES * velocity) / mass;
            velocity = velocity + acceleration * Time.deltaTime;
        }else if (!is_flying)
        {
            velocity = move_speed * direction;
        }
        gameObject.transform.Translate(velocity * Time.deltaTime);

    }

    public void SetDirection(Vector3 vec3)
    {
        direction = vec3;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ocean")
        {
            //gameObject.transform.Translate(-velocity * Time.deltaTime * 2);
            //velocity = -velocity;
            gameObject.transform.position = gameObject.transform.position * -1;
        }

    }
}
