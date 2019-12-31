using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Location {
    public float x;
    public float y;
    public float z;

    public Location(float x, float y, float z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

public class Miner {
    public Location location;
    public bool vertical;
    public int speed;
    public int changeTime;

    public Miner(Location location, bool vertical, int speed, int changeTime) {
        this.location = location;
        this.vertical = vertical;
        this.speed = speed;
        this.changeTime = changeTime;
    }
}

