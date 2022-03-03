using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public Vector2 Point,   // 坐标
                   Position;    // 坐标对应的位置

    public bool IsFood = false; // 是否已存在食物

    public Grid(Vector2 point,Vector2 position) {
        Point = point;
        Position = position;
    }
}
