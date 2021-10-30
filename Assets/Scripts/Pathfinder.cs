using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    bool isFindingPath = true;
    Waypoint searchCenter;
    List<Waypoint> path = new List<Waypoint>();

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
    }

    private void BreadthFirstSearch()
    {

        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isFindingPath)
        {
            searchCenter = queue.Dequeue();

            StopIfEndFound();

            ExploreNeighbours();
            searchCenter.isExplored = true;
        }

    }

    private void StopIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
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

    private void ExploreNeighbours()
    {
        if (!isFindingPath) return;
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCords = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(explorationCords))
            {
                QueueNewNeighbours(explorationCords);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int explorationCords)
    {
        
        Waypoint neighbour = grid[explorationCords];

        if (neighbour.isExplored || queue.Contains(neighbour))
        {

        }
        else
        {
            queue.Enqueue(neighbour);

            neighbour.exploredFrom = searchCenter;
        }
        
    }

    private void CreatePath()
    {
        SetAsPath(endWaypoint);

        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
        {
            SetAsPath(previous);

            previous = previous.exploredFrom;
        }

        SetAsPath(startWaypoint);
        path.Reverse();
    }

    private void SetAsPath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceable = false;
    }
}
