using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement_controller : MonoBehaviour
{
    public int speed;
    void Start()
    {
        Cursor.visible = false;
        speed = 1;
    }
    void Update()
    {
        faceMouse();
        move();
    }
    void faceMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 pos = ray.origin + (ray.direction);

        transform.LookAt(new Vector3(pos.x, transform.position.y, pos.z));
    }
    void move()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += new Vector3(0, 0, speed);
        if (Input.GetKey(KeyCode.S))
            transform.position -= new Vector3(0, 0, speed);
        if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(speed, 0, 0);
        if (Input.GetKey(KeyCode.A))
            transform.position -= new Vector3(speed, 0, 0);
    }
}
