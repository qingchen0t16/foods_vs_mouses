using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    // ����
    private int fireNum;    // ��������
    public int FireNum
    {
        get => fireNum;
        set
        {
            fireNum = value;
            UIManager.Instance.UpdateFireNum(FireNum);
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        FireNum = 50;
    }
}
