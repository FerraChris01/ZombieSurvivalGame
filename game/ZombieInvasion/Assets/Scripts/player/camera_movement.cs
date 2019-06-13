using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player;
    [SerializeField] float smoothTime;
    private Vector3 velocity;
    private void Start()
    {
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y , player.transform.position.z);
       // transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), ref velocity, smoothTime * Time.deltaTime);
    }
}
