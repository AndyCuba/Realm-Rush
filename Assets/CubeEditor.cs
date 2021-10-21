using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase] // ��� ������ � ��������� ������ ������� � �� ��� �����
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        SnapToGrid();

        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        

        transform.position = new Vector3(
            waypoint.GetGridPos().x,
            0f,
            waypoint.GetGridPos().y
        );
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();
        Vector2Int gridPos = waypoint.GetGridPos();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = gridPos.x / gridSize + "," + gridPos.y / gridSize;
        textMesh.text = labelText;

        gameObject.name = labelText;
    }
}
