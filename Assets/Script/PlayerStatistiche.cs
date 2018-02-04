using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistiche : MonoBehaviour {

    public int distanceMove = 1; //di quante caselle può muoversi

    public void SetDistace(int Distance) {
        distanceMove = Distance;
    }

    public int GetDistance() {
        return distanceMove;
    }
}
