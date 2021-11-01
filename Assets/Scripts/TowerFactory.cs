using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    
    public void AddTower(Waypoint waypoint)
    {
        Tower[] towers = FindObjectsOfType<Tower>();

        if (towers.Length < 5)
        {
            InstantiateTower(waypoint);
        }
    }

    private void InstantiateTower(Waypoint waypoint)
    {
        Instantiate(towerPrefab, waypoint.transform.position, Quaternion.identity);
        waypoint.isPlaceable = false;
    }

}
