using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoint;
    private Transform waypointTransform;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;


    private void Update()
    {
        waypointTransform = waypoint[currentWaypointIndex].transform;
        if (Vector2.Distance(waypointTransform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
        }
            Debug.Log(currentWaypointIndex);

        if (currentWaypointIndex >= waypoint.Length)
        {
            currentWaypointIndex = 0;
        }

        transform.position = Vector2.MoveTowards(transform.position, waypointTransform.position, Time.deltaTime * speed);
    }
}
