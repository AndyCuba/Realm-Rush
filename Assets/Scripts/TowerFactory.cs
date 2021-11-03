using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerQueue = new Queue<Tower>();
    public void AddTower(Waypoint waypoint)
    {

        if (towerQueue.Count < towerLimit)
        {
            InstantiateTower(waypoint);
        }
        else
        {
            MoveExistingTower(waypoint);
        }
    }

    private void MoveExistingTower(Waypoint waypoint)
    {
        Tower oldTower = towerQueue.Dequeue();

        oldTower.baseWaypoint.isPlaceable = true;
        waypoint.isPlaceable = false;

        oldTower.baseWaypoint = waypoint;
        oldTower.transform.position = waypoint.transform.position;

        towerQueue.Enqueue(oldTower);
    }

    private void InstantiateTower(Waypoint waypoint)
    {
        Tower newTower = Instantiate(towerPrefab, waypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform;
        waypoint.isPlaceable = false;

        newTower.baseWaypoint = waypoint;

        towerQueue.Enqueue(newTower);
    }

}
