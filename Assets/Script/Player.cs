using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Transform myTransform;
    public GameObject grid;


	void Start () {
        myTransform = GetComponent<Transform>();
	}
	

	void Update () {
        myTransform.position = grid.GetComponent<Grid>().selectedCasella.position;
        

    }
}
