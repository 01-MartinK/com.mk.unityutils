using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridXZ<TGridObject>
{
    public event EventHandler<OnGridObjectChangedEventArgs> OnGridObjectChanged;
    public class OnGridObjectChangedEventArgs : EventArgs
    {
        public int x, y;
    }

    private int width;
    private int height;
    private float cellSize;
    private Vector3 origin;
    private TGridObject[,] gridArray;
    
    public GridXZ(int width, int height, float cellSize, Vector3 originPosition, Func<GridXZ<TGridObject>, int, int, TGridObject> createGridObject )
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.origin = originPosition;

        gridArray = new TGridObject[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x, y] = createGridObject(this, x, y);
            }
        }
    }

	public Vector3 ToWorldPosition(Vector2Int position) 
	{
		return new Vector3(position.x, 0, position.y) * cellSize + origin;
	}

    public Vector3 ToWorldPosition(int x, int y)
    {
        return new Vector3(x, 0, y) * cellSize + origin;
    }

    public Vector3 ToWorldPosition(int x, int y, int z)
    {
        return new Vector3(x, y, z) * cellSize + origin;
    }

    public Vector2Int ToGridPosition(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt((worldPosition - origin).x / cellSize);
        int y = Mathf.FloorToInt((worldPosition - origin).z / cellSize);
        return new Vector2Int(x, y);
    }

    public void ToGridPosition(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - origin).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - origin).z / cellSize);
    }

    public Vector2Int ToGridPosition(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt((worldPosition - origin).x / cellSize);
        int y = Mathf.FloorToInt((worldPosition - origin).y / cellSize);
		return new Vector2Int(x, y);
	}

    public void SetGridValue(int x, int y, TGridObject value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            if (OnGridObjectChanged != null) OnGridObjectChanged(this, new OnGridObjectChangedEventArgs { x = x, y = y });
        }
    }

    public void SetGridValue(Vector3 worldPosition, TGridObject value)
    {
        ToGridPosition(worldPosition, out int x, out int y);
        SetGridValue(x, y, value);
        if (OnGridObjectChanged != null) OnGridObjectChanged(this, new OnGridObjectChangedEventArgs { x = x, y = y });
    }

    public TGridObject GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < width)
        {
            return gridArray[x, y];
        }else
        {
            return default(TGridObject);
        }
    }

    public TGridObject GetGridObject(Vector3 worldPosition)
    {
        ToGridPosition(worldPosition, out int x, out int y);
        return gridArray[x, y];
    }

    public float GetCellSize()
    {
        return this.cellSize;
    }

    public int GetWidth()
    {
        return this.width;
    }

    public int GetHeight()
    {
        return this.height;
    }

    public Vector3 GetOrigin()
    {
        return this.origin;
    }
	
	public void DrawGrid(Color color) {
        Gizmos.color = color;

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                Gizmos.DrawLine(ToWorldPosition(x, y), ToWorldPosition(x, y + 1));
                Gizmos.DrawLine(ToWorldPosition(x, y), ToWorldPosition(x + 1, y));
            }
        }

        Gizmos.DrawLine(ToWorldPosition(0, height), ToWorldPosition(width, height));
        Gizmos.DrawLine(ToWorldPosition(width, 0), ToWorldPosition(width, height));
    }

    public void DrawGridValues(Color color) {
        GUIStyle newStyle = new GUIStyle();
        newStyle.alignment = TextAnchor.MiddleCenter;
        newStyle.normal.textColor = color;

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (GetGridValue(x, y) != null)
                    Handles.Label(ToWorldPosition(x, y) + new Vector3(cellSize / 2, 0, cellSize / 2), GetGridValue(x, y).ToString(), newStyle);
            }
        }
    }
}
