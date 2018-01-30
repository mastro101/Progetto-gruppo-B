using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public GameObject casella;
    public List<CellData> Cells = new List<CellData>();

    public int xSize;
    public int zSize;



    private void Awake()
    {
        Cells = new List<CellData>();
        GridSize(5, 3);
    }


    void Start()
    {

    }



    void GridSize(int x, int z)
    {
        for (int _x = 0; _x < x; _x++)
        {
            for (int _z = 0; _z < z; _z++)
            {
                Cells.Add(new CellData(_x, _z, new Vector3(casella.transform.localScale.x * _x, 0, casella.transform.localScale.z * _z)));
            }
        }

        for (int _x = 0; _x < x; _x++)
        {
            for (int _z = 0; _z < z; _z++)
            {
                CellData cell = Cells.Find(c => c.X == _x && c.Z == _z);
                // Debug
                GameObject casellaClone = Instantiate(casella);
                casellaClone.transform.position += new Vector3(casella.transform.localScale.x * _x, casella.transform.position.y, casella.transform.localScale.z * _z);
            }
        }
        xSize = x;
        zSize = z;
    }

    #region API

    public CellData FindCell(int x, int z)
    {
        return Cells.Find(c => c.X == x && c.Z == z);
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
