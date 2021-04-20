using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeparturePoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hero hero = collision.gameObject.GetComponent<Hero>();
        if (!hero) { return; }
        else
        {
            hero.is_flying = true;
            Debug.Log("departure!");
        }
    }
}
