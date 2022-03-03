using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Text fireNumText; // ������ʾ�ı�

    private void Awake()
    {
        Instance = this;
        fireNumText = GameObject.Find("UI/CarBar/FireText").GetComponent<Text>();
    }

    private void Start()
    {
        
    }

    /// <summary>
    /// ���»�������
    /// </summary>
    /// <param name="num"></param>
    public void UpdateFireNum(int num) {
        fireNumText.text = num.ToString();
    }

    /// <summary>
    /// ��ȡ������ʾ�����λ��
    /// </summary>
    public Vector3 GetFirePos() {
        return fireNumText.transform.position;
    }
}
