using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class Robot : MonoBehaviour
{
    //private int startPosX = 0;
    //private int startPosY = 0;
    //private int currentX;
    //private int currentY;
    //public float speed = 3.0f;
    //private float step = 1;
    //public bool isMoving = false;

    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    public bool isWalking;
    public float walkTime;
    private float walkCounter;
    public float waitTiem;
    private float waitCounter;
    private int walkDirection;

    public Maze maze;

    void Start()
    {
        maze.CreateGrid();
        myRigidbody = GetComponent<Rigidbody2D>();

        waitCounter = waitTiem;
        walkCounter = walkTime;

        ChoosDirection();

       // maze.Choose();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;

            switch(walkDirection)
            {
                // up
                case 0:
                    myRigidbody.velocity = new Vector2(0, moveSpeed);
                    break;
                // down
                case 1:
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);
                    break;
                // left
                case 2:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    break;
                // right
                case 3:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    break;
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTiem;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;

            if (waitCounter < 0)
            {
                ChoosDirection();
            }
        }

        //currentX = Mathf.FloorToInt(transform.position.x);
        //currentY = Mathf.FloorToInt(transform.position.y);

        //var step = speed * Time.deltaTime;
        //var pos = transform.position;
        //if (isMoving)
        //{
        //   transform.position = Vector3.MoveTowards(pos, 2.0, step);
        //}   
        //var pos = transform.position;
        //transform.position = new Vector3(pos.x + speed, pos.y, pos.z);

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    Debug.Log("Left Arrow");
        //    transform.Translate(-step * Time.deltaTime, 0, 0);
        //}

        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(step * Time.deltaTime, 0, 0);
        //}

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.Translate(0, step * Time.deltaTime, 0, 0);
        //}

        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.Translate(0, -step * Time.deltaTime, 0, 0);
        //}
    }

    public void ChoosDirection()
    {
        // walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ///walkDirection = Random.Range(0, 4);

        walkDirection = 1;

        if (collision.gameObject.tag == "Wall")
        {
            // Debug.Log("Collision");
            walkDirection = 3;
            isWalking = true;
            walkCounter = walkTime;
        }
    }
}
