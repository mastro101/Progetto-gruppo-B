using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public GameObject Tile;
    public List<CellData> Cells = new List<CellData>();
    public float CellSize = -1;
    public int xSize;
    public int zSize;
    public string NameTile;
    public int Width = 0, Height = 0;

    public float DistanceTile;



    private void Awake()
    {
        Cells = new List<CellData>();
        GridSize(Width, Height);
    }

    void GridSize(int x, int z)
    {
        xSize = x;
        zSize = z;
        string ControlCity;

        CellSize = Tile.transform.localScale.x + DistanceTile;

        for (int _x = 0; _x < x; _x++)
        {
            for (int _z = 0; _z < z; _z++)
            {
                
                Cells.Add(new CellData(_x, _z, new Vector3(_x * CellSize, transform.position.y, _z * CellSize), NameTile));
            }
        }

        SetCity();

        for (int _x = 0; _x < x; _x++)
        {
            for (int _z = 0; _z < z; _z++)
            {
                CellData cell = FindCell(_x, _z);
                // Debug
                if (cell.IsValid)
                {
                    GameObject tile = (GameObject)Instantiate(Tile);
                    tile.transform.position = cell.WorldPosition;

                    if (cell == Center())
                    {
                        tile.GetComponent<Renderer>().material.color = Color.black;
                    }

                    
                    ControlCity = FindCell(_x, _z).GetNameTile();
                    if (ControlCity != "")
                        tile.GetComponent<Renderer>().material.color = Color.red;
                        Debug.Log(ControlCity);
                }
            }
        }

    }



    void SetCity() {
        FindCell(0, 2).SetNameTile("A");
        FindCell(2, 1).SetNameTile("B");
        FindCell(3, 3).SetNameTile("C");
        FindCell(4, 0).SetNameTile("D");
        FindCell(4, 4).SetNameTile("E");
        FindCell(6, 3).SetNameTile("F");
        FindCell(7, 1).SetNameTile("G");
        FindCell(9, 2).SetNameTile("H");
    }

    /*void ChangeColorTileCity() {
        string ControlCity;
        for (int _x = 0; _x < Width; _x++)
        {
            for (int _z = 0; _z < Height; _z++)
            {

                ControlCity = FindCell(_x, _z).GetNameTile();
                if (ControlCity != "")
                    //material.color = Color.red;
                    Debug.Log(ControlCity);
            }
        }
    }*/

    public int GetWidth() {
        return Width;
    }

    public int GetHeight() {
        return Height;
    }

    #region API

    public CellData FindCell(int x, int z)
    {
        return Cells.Find(c => c.X == x && c.Z == z);
    }

    public CellData Center()
    {
        int w = Width / 2;
        int h = Height / 2;
        return Cells.Find(c => c.X == w && c.Z == h);
    }

    public Vector3 GetWorldPosition(int x, int z)
    {
        foreach (CellData cell in Cells)
        {
            if (cell.X == x && cell.Z == z)
            {
                return cell.WorldPosition;
            }
        }
        return Cells[0].WorldPosition;
    }

    public bool IsValidPosition(int x, int z)
    {
        if (x < 0 || z < 0)
            return false;
        if (x > xSize - 1 || z > zSize - 1)
            return false;

        return true;
    }

        #endregion
}
