using Assets.Resources.Game.Food.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FoodManager : MonoBehaviour
{
    public static FoodManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// 获取食物的预制体
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public GameObject GetFoodByType(FoodType type) {
        return GameingManager.Instance.GameingConf.Pf_Food[(int)type];
    }
}
