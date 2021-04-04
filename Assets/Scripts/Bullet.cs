using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        gameObject.transform.Translate(velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
