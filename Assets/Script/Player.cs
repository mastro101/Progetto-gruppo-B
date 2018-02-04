using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Grid grid;
    public PlayerStatistiche playerStatistiche;
    public int XPos;
    public int ZPos;

    int XPos_old;
    int ZPos_old;

    int DistanceMove;

    //Quaternion sinistra = new Vector3 (0f,0f,0f);

    // Use this for initialization
    void Start()
    {
        transform.position = grid.GetWorldPosition(XPos, ZPos);
        transform.position += new Vector3(0f, 0.55f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        XPos_old = XPos;
        ZPos_old = ZPos;
        DistanceMove = playerStatistiche.GetDistance();
        if (Input.GetKeyDown(KeyCode.A))//Sinistra
        {
            XPos-=DistanceMove;
            Move();
        }
        else if (Input.GetKeyDown(KeyCode.D))//Destra
        {
            XPos += DistanceMove;
            Move();
        }
        else if (Input.GetKeyDown(KeyCode.W))//Su
        {
            ZPos += DistanceMove;
            Move();
        }
        else if (Input.GetKeyDown(KeyCode.S))//Giu
        {
            ZPos -= DistanceMove;
            Move();
        }


    }

    private void Move()
    {
        if (grid.IsValidPosition(XPos, ZPos))
        {
            transform.position = grid.GetWorldPosition(XPos, ZPos);
            transform.position += new Vector3(0f, 0.55f, 0f);
        }
        else
        {
            XPos = XPos_old;
            ZPos = ZPos_old;
        }
    }
}
