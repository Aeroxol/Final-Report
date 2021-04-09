using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBody : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 acceleration;
    private float mass;
    public float Mass
    {
        get { return mass; }
        set { mass = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
        acceleration = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        velocity = velocity + acceleration * Time.deltaTime;
        gameObject.transform.Translate(velocity * Time.deltaTime);
    }
}
