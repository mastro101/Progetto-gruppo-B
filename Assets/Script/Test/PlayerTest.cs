using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour {

    public GridTest grid;
    public int XPos;
    public int ZPos;

    int XPos_old;
    int ZPos_old;

    // Use this for initialization
    void Start () {
        transform.position = grid.GetWorldPosition(XPos, ZPos);
	}
	
	// Update is called once per frame
	void Update () {
        XPos_old = XPos;
        ZPos_old = ZPos;
		if (Input.GetKeyDown(KeyCode.A))
        {
            XPos--;
            Move();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            XPos++;
            Move();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            ZPos++;
            Move();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            ZPos--;
            Move();
        }
        

    }

    private void Move()
    {
        if (grid.IsValidPosition(XPos, ZPos))
        {
            transform.position = grid.GetWorldPosition(XPos, ZPos);
        }
        else
        {
            XPos = XPos_old;
            ZPos = ZPos_old;
        }
    }
}
