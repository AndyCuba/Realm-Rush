using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    void Start()
    {
        LoadBlocks();
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();

        foreach(Waypoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos();

            bool isWaypointExists = grid.ContainsKey(gridPos);

            if (!isWaypointExists)
            {
                grid.Add(gridPos, waypoint);
            }
        }

        print(grid.Count);
    }
}
