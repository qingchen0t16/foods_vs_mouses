using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private List<Grid> gridList;

    private void Start()
    {
        gridList = new List<Grid>();
        CreateGridsPoint();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            print(GetGridByMouse().Point);
    }

    /// <summary>
    /// ��ʼ����������
    /// </summary>
    private void CreateGridsPoint() {
        for (int i = 0; i < 9; i++)
            for (int j = 0; j < 7; j++)
                gridList.Add(new Grid(
                        new Vector2(i,j),
                        new Vector2(-1.38F + 0.59F * i, -2.29F + 0.64F * j))
                    );
    }

    /// <summary>
    /// ��ȡ����������һ������
    /// </summary>
    /// <returns></returns>
    public Grid GetGridByMouse() => GetGridByWorldPos(Camera.main.ScreenToWorldPoint(Input.mousePosition));

    /// <summary>
    /// ͨ��Vector2����Ѱ������
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public Grid GetGridByWorldPos(Vector2 pos) {
        float dis = 99999999F;
        Grid point = null;
        for (int i = 0; i < gridList.Count; i++)
            if (Vector2.Distance(pos, gridList[i].Position) < dis)
            {
                dis = Vector2.Distance(pos, gridList[i].Position);
                point = gridList[i];
            }
        return point;
    }
}
