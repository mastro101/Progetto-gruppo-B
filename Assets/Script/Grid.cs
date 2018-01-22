using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public GameObject casella;
    GameObject[,] grid;

	void Start () {

        // Crea una griglia (X x Z)
        gridSize(10,10);

	}
	


    void gridSize(int x, int z)
    {
        // Crea un array grande quanto la griglia
        grid = new GameObject[x,z];

        // Crea cloni delle caselle per formare la griglia
        for (int i = 0; i < x; i++)
        {
            for (int n = 0; n < z; n++)
            {                
                GameObject gridPlane = Instantiate(casella);
                gridPlane.transform.position += new Vector3(0.50038f * i, 0, 0.50038f * n);                
            }
        }
    }
}
