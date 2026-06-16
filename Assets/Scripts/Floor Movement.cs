using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class FloorMovement : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;

    [SerializeField] GameObject CD;
    CDetection controller;

    [SerializeField] float speed = 1f;

    private void Start()
    {
        CDetection controller = CD.GetComponent<CDetection>();

    }

    void Update()
    {
        if (controller.colliding == true)
        {
            if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}