using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTest : MonoBehaviour {


    public GameObject casella;
    public List<CellDataTest> Cells = new List<CellDataTest>();




    private void Awake()
    {
        Cells = new List<CellDataTest>();
        GridSize(5, 3);
    }


    void Start()
    {

    }



    void GridSize(int x, int z)
    {


        for (int X = 0; X < x; X++)
        {
            for (int Z = 0; Z < z; Z++)
            {
                Cells.Add(new CellDataTest(X, Z, new Vector3(casella.transform.localScale.x * X, 0, casella.transform.localScale.z * Z)));
            }
        }

        for (int X = 0; X < x; X++)
        {
            for (int Z = 0; Z < z; Z++)
            {
                CellDataTest cell = Cells.Find(c => c.X == X && c.Z == Z);
                // Debug
                GameObject casellaClone = Instantiate(casella);
                casellaClone.transform.position += new Vector3(casella.transform.localScale.x * X, casella.transform.position.y, casella.transform.localScale.z * Z);
            }
        }



            }

    #region API

    public CellDataTest FindCell(int x, int z)
    {
        return Cells.Find
    }


    public bool IsValidPosition(int x, int z)
    {
        if (x < 0 || z < 0)
            return false;
        if (x > X - 1 || Z > z - 1)
            return false;

        return true;
    }
    /// <summary>
    /// Restituisce la worldposition per la posizione della cella richiesta
    /// </summary>
    /// <param name="x"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    public Vector3 GetWorldPosition(int x, int z)
    {
        foreach (CellDataTest cell in Cells)
        {
            if(cell.X == x && cell.Z == z)
            {
                return cell.WorldPosition;
            }
        }
        return Cells[0].WorldPosition;
    }

    #endregion



}
