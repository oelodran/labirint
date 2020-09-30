using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot2 : MonoBehaviour
{
    public float speed = 2.0f;
    public Maze maze;

    void Start()
    {
        // maze.Choose();
    }

    void Update()
    {
        //var pos = transform.position;
        //transform.position = new Vector3(pos.x + speed, pos.y, pos.z);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Left Arrow");
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0, 0);
        }
    }
}
