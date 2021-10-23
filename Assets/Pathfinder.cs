using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    [SerializeField] bool isFindingPath = true;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        Pathfind();
    }

    private void Pathfind()
    {

        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isFindingPath)
        {
            var searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;

            StopIfEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
        }

        print("Finding finished");
    }

    private void StopIfEndFound(Waypoint waypoint)
    {
        if (waypoint == endWaypoint)
        {
            print("Start is the same with end");
            isFindingPath = false;
        }

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

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.red);
        endWaypoint.SetTopColor(Color.blue);

    }

    private void ExploreNeighbours(Waypoint searchFrom)
    {
        if (!isFindingPath) return;

        foreach(Vector2Int direction in directions)
        {
            Vector2Int explorationCords = searchFrom.GetGridPos() + direction;
            try
            {
                QueueNewNeighbours(explorationCords);
            }
            catch (Exception)
            {
                //do nothing
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int explorationCords)
    {
        
        Waypoint neighbour = grid[explorationCords];

        if (neighbour.isExplored)
        {

        }
        else
        {
            neighbour.SetTopColor(Color.blue);

            queue.Enqueue(neighbour);
            print("Queuing new neighbour" + neighbour);
        }
        
    }
}
