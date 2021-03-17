using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static float mouse_x;
    public static float mouse_y;
    public static Vector2 mouse_xy = Vector3.zero;
    public static float keyboard_x;
    public static float keyboard_y;
    public static Vector2 keyboard_xy = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
        mouse_xy.x = mouse_x = Input.mousePosition.x;
        mouse_xy.y = mouse_y = Input.mousePosition.y;
        keyboard_xy.x = keyboard_x = Input.GetAxis("Horizontal");
        keyboard_xy.y = keyboard_y = Input.GetAxis("Vertical");
    }
}
