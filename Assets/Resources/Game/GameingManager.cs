using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameingManager : MonoBehaviour
{
    public static GameingManager Instance;
    public GameingConf GameingConf;

    // …Ë÷√
    public bool IsAutoFire = false;

    private void Awake()
    {
        Instance = this;
        GameingConf = Resources.Load<GameingConf>("Game/GameingConf");
    }

    private void Start()
    {
        IsAutoFire = true;
    }

}
