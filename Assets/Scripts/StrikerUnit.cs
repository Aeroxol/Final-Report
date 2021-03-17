using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikerUnit : MonoBehaviour
{
    private Hero pilot;
    [SerializeField]
    private float power = 10;
    [SerializeField]
    private float mass = 10;
    private float mana;
    private Vector2 velocity = Vector3.zero;

    private void Start()
    {
        
    }
    private void Update()
    {
        Flight();
    }
    public void Flight()
    {
        if (this.isActiveAndEnabled)
        {
            // a = (F - kv)/mass
            Vector2 a = (power * Controller.keyboard_xy - this.velocity * Constants.AIR_RES) / this.mass;
            this.velocity += a;
            gameObject.transform.Translate(this.velocity * Time.deltaTime);
        }
    }
}
