using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ϸ����������
/// </summary>
[CreateAssetMenu(fileName = "GameingConf",menuName = "GameingConf")]
public class GameingConf : ScriptableObject
{
    [Tooltip("��������")]
    public GameObject Pf_Fire;
    [Tooltip("С��¯")]
    public GameObject[] Pf_Food;
}
