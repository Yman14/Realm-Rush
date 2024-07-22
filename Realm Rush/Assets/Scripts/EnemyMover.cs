using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float enemyMovementSpeed = 1f;

    void Start()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    // void FindPath()
    // {
    //     path.Clear();


    //     GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

    //     foreach(GameObject waypoint in waypoints)
    //     {
    //         path.Add(waypoint.GetComponent<Waypoint>());
    //     }
    // }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1f)
            {
                travelPercent += enemyMovementSpeed * Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return null;
            }

            
        }

        Destroy(gameObject);
    }

    void FindPath()
    {
        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in parent.transform)
        {
            path.Add(child.GetComponent<Waypoint>());
        }
    }
}
