using Assets.Client;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWDManager : ClientMonoBehaviour
{
    // 获取当前所有窗口
    public Transform MainCity_UI, MainCity_Control, _Map_MeiWeidao, UserBox, MessageBox, Activity, EMail;
    // 单例
    public static MainWDManager Instance;

    private void Awake()
    {
        Instance = this;
        MainCity_UI = GameObject.Find("MainCity_UI").transform;
        MainCity_Control = GameObject.Find("MainCity_Control").transform;
        _Map_MeiWeidao = GameObject.Find("_Map_Meiweidao").transform;
        UserBox = GameObject.Find("UserBox").transform;
        MessageBox = GameObject.Find("MessageBox").transform;
        Activity = GameObject.Find("Activity").transform;
        EMail = GameObject.Find("EMail").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        MainCity_UI.gameObject.SetActive(true);
        MainCity_Control.gameObject.SetActive(true);
        _Map_MeiWeidao.gameObject.SetActive(false);
        UserBox.gameObject.SetActive(true);
        MessageBox.gameObject.SetActive(true);
        Activity.gameObject.SetActive(false);
        EMail.gameObject.SetActive(false);
    }

    public override void _Update()
    {
    }

    public override void OnDesconnected()
    {
        GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "提示", "与服务器连接已断开", null, true, () => {
            Application.Quit();
        });
    }
}
