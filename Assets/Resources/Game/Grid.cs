using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public Vector2 Point,   // ����
                   Position;    // �����Ӧ��λ��

    public bool IsFood = false; // �Ƿ��Ѵ���ʳ��

    public Grid(Vector2 point,Vector2 position) {
        Point = point;
        Position = position;
    }
}
