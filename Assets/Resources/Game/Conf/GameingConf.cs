using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏进行中配置
/// </summary>
[CreateAssetMenu(fileName = "GameingConf",menuName = "GameingConf")]
public class GameingConf : ScriptableObject
{
    [Tooltip("正常火苗")]
    public GameObject Pf_Fire;
    [Tooltip("小火炉")]
    public GameObject[] Pf_Food;
}
