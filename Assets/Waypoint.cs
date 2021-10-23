using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;

    Vector2Int gridPos;
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

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();

        topMeshRenderer.material.color = color;
    }
}
