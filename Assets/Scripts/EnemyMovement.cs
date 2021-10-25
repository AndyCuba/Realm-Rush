using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();

        List<Waypoint> path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    private IEnumerator FollowPath(List<Waypoint> path)
    {
        print("starting patroll..");

        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(2f); // magic number!
        }

        print("patrol is finished");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
