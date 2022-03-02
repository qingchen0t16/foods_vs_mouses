using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyFireManager : MonoBehaviour
{
    public float[] CreatePosX = new float[] {143F,345F };
    public Vector2 CreatePos;   // ª√Á…˙≥…Œª÷√

    // Start is called before the first frame update
    void Start()
    {
        CreatePos = new Vector2(Random.Range(CreatePosX[0], CreatePosX[1]), 330F);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
