using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement_controller : MonoBehaviour
{
    #region Singleton
    public static player_movement_controller instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
    [SerializeField] float speed;
    [SerializeField] bool canMove;
    public bool CanMove { get => canMove; set => canMove = value; }
    public float PlayerSpeed { get => playerSpeed; set => playerSpeed = value; }

    private float playerSpeed;

    void Start()
    {
        playerSpeed = speed;
        Cursor.visible = false;
        canMove = true;
    }
    void Update()
    {
        faceMouse();
        move();
        Debug.Log("speed: " + playerSpeed);
    }
    void faceMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 pos = ray.origin + (ray.direction);

        transform.LookAt(new Vector3(pos.x, transform.position.y, pos.z));
    }
    void move()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, 0, playerSpeed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position -= new Vector3(0, 0, playerSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(playerSpeed, 0, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(playerSpeed, 0, 0);
            }
        }
    }
    public void resetSpeed()
    {
        playerSpeed = speed;
    }
}
