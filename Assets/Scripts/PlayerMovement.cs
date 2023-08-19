using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed;

    public Rigidbody rb;

    private int lane = 1;// 0 1 2 left to right

    public float maxSwipeTime;
    public float minSwipeDistance;

    private float swipeStartTime;
    private float swipeEndTime;
    private float swipeTime;

    private Vector2 startSwipePosition;
    private Vector2 endSwipePosition;
    private float swipeLenght;
    

    void Update()
    {
        SwipeTest();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, forwardSpeed * Time.deltaTime);
    }

    
    void SwapLanes(string whereToMove)
    {
        if (whereToMove == "Right" && lane == 0)
        {
            transform.position += new Vector3(3, 0, 0);
            lane = 1;
        }
        else if (whereToMove == "Right" && lane == 1)
        {
            transform.position += new Vector3(3, 0, 0);
            lane = 2;
        }
        else if (whereToMove == "Left" && lane == 1)
        {
            transform.position += new Vector3(-3, 0, 0);
            lane = 0;
        }
        else if (whereToMove == "Left" && lane == 2)
        {
            transform.position += new Vector3(-3, 0, 0);
            lane = 1;
        }
    }

    void SwipeTest()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                swipeStartTime = Time.time;
                startSwipePosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                swipeEndTime = Time.time;
                endSwipePosition = touch.position;
                swipeTime = swipeEndTime - swipeStartTime;
                swipeLenght = (endSwipePosition - startSwipePosition).magnitude;

                if (swipeTime<maxSwipeTime && swipeLenght > minSwipeDistance)
                {
                    swipeControl();
                }
            }
        }

    }

    void swipeControl()
    {
        Vector2 Distance = endSwipePosition - startSwipePosition;
        float xDistance = Mathf.Abs(Distance.x);
        float yDistance = Mathf.Abs(Distance.y);

        if (xDistance > yDistance)
        {
            if (Distance.x > 0)
            {
                SwapLanes("Right");
            }
            else if (Distance.x < 0)
            {
                SwapLanes("Left");
            }
        }
    }

}
