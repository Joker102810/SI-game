using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class FloorMovement : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    //int currentWaypointIndex = 0;

    [SerializeField] GameObject CD;
    CDetection controller;

    [SerializeField] float speed;

    bool hasArrived = false;
    public bool move = false;

    private void Start()
    {

        //Debug.Log(CD);
        
        controller = CD.GetComponent<CDetection>();

    }

    void Update()
    {
        if (controller.colliding)
        {
            move = true;
        }

        if (!hasArrived && move == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[1].transform.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, waypoints[1].transform.position) < 0.1f)
            {
                hasArrived = true;
                move = false;

                // Next action here
            }
        }
    }
}