using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        int GridPosX = Mathf.RoundToInt(transform.position.x / gridSize);
        int GridPosZ = Mathf.RoundToInt(transform.position.z / gridSize);

        return new Vector2Int(GridPosX, GridPosZ);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                PlaceTower();
            }
            else
            {
                print("cant place tower here");
            }
        }
    }

    private void PlaceTower()
    {
        print("placing tower");
        Instantiate(towerPrefab, transform.position, Quaternion.identity);
        isPlaceable = false;
    }
}
