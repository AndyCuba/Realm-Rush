using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Vector2Int gridPos;
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        int GridPosX = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        int GridPosZ = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        return new Vector2Int(GridPosX, GridPosZ);
    }
}
