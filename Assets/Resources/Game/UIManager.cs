using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Text fireNumText; // 火苗显示文本

    private void Awake()
    {
        Instance = this;
        fireNumText = GameObject.Find("UI/CarBar/FireText").GetComponent<Text>();
    }

    private void Start()
    {
        
    }

    /// <summary>
    /// 更新火苗数量
    /// </summary>
    /// <param name="num"></param>
    public void UpdateFireNum(int num) {
        fireNumText.text = num.ToString();
    }

    /// <summary>
    /// 获取火苗显示区域的位置
    /// </summary>
    public Vector3 GetFirePos() {
        return fireNumText.transform.position;
    }
}
