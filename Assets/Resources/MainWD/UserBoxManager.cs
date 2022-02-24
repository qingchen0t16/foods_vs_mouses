using FVMIO_From_Standard2_0.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserBoxManager : MonoBehaviour
{
    // ����
    public static UserBoxManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// ˢ���û����
    /// �ֺü�����д
    /// ˢ�²�ͬ������
    /// </summary>
    /// <param name="data"></param>
    public void PanelUpDate(UserData data) {
        print("�����û���Ϣ");

        transform.Find("NickName").GetComponent<Text>().text = data.UserName;
        transform.Find("LevelProText").GetComponent <Text>().text = $"{Math.Round(1.0F * data.Level.Exp / data.Level.NeedExp * 100, 2)}%";

        transform.Find("LevelPro").GetComponent<Slider>().value = 1.0F * data.Level.Exp / data.Level.NeedExp;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
