using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public Transform selectedCasella;
    public GameObject casella;
    public GameObject[,] grid;

    int xAxis = 0;
    int zAxis = 0;
    public int selectedX = 0;
    public int selectedZ = 0;
    void Start () {

        // Crea una griglia (X x Z)
        GridSize(10,3);
        selectedCasella = grid[0, 0].transform;
        
	}

    private void Update()
    {
        
        // Elimina una casella
        Select();
        
    }

    void GridSize(int x, int z)
    {
        // Crea un array grande quanto la griglia
        grid = new GameObject[x,z];

        // Crea cloni delle caselle per formare la griglia
        for (int X = 0; X < x; X++)
        {
            for (int Z = 0; Z < z; Z++)
            {
                GameObject casellaClone = Instantiate(casella);
                Destroy(casellaClone.GetComponent<Grid>());
                casellaClone.transform.position += new Vector3(casella.transform.localScale.x * X, 0,casella.transform.localScale.z * Z);
                // Assegna le caselle alla Griglia
                grid[X,Z] = casellaClone;
                xAxis = X;
                zAxis = Z;
            }
            Destroy(gameObject.GetComponent<MeshRenderer>());
        }
        
    }





    void Select()
    {
        

        if (Input.GetKeyDown(KeyCode.RightArrow) && selectedX < xAxis)
        {
            selectedX++;
            Debug.Log("x = " + selectedX);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && selectedX > 0)
        {
            selectedX--;
            Debug.Log("x = " + selectedX);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && selectedZ < zAxis)
        {
            selectedZ++;
            Debug.Log(selectedZ);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && selectedZ > 0)
        {
            selectedZ--;
            Debug.Log(selectedZ);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Destroy(grid[selectedX,selectedZ].GetComponent<MeshRenderer>());
        }

        selectedCasella = grid[selectedX, selectedZ].transform;
    }
}
