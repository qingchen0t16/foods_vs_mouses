using Assets.Client;
using SCPublic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 加载管理器
/// </summary>
public class LoadManager : ClientMonoBehaviour
{
    private Text LoadStatu;
    private Text AlertText;
    private Slider LoadProgress;
    private List<string> alertContents = new List<string>(); 

    private void Awake()
    {
        // 绑定组件
        LoadStatu = GameObject.Find("LoadContent/LoadStatu").GetComponent<Text>();
        AlertText = GameObject.Find("LoadContent/AlertText/Text").GetComponent<Text>();
        LoadProgress = GameObject.Find("LoadContent/LoadProgress").GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadProgress.value = 0;
        LoadStatu.text = "正在获取玩家数据..";
        AlertText.text = "";
        alertContents.AddRange(new string[]{"显示内容1","显示内容2","显示内容3","显示内容4" });
        InvokeRepeating("StartShowAlertText", 0,3);
        GetUserData();
    }

    /// <summary>
    /// 获取玩家数据
    /// </summary>
    public void GetUserData() {
        ClientManager.Instance.Respones.Send<string>(ClientManager.Instance.Request, SCPublic.SendType.Text, GameManager.Instance.User.UserID.ToString(), (sp) =>
        {
            EventProcessor.QueueEvent(() =>
            {
                if (sp.GetSource<UserData>().UserID == -1)
                    GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "提示", "无法获取玩家数据", null, true, () =>
                    {
                        Application.Quit();
                    });
                else
                {
                    GameManager.Instance.User.UserData = sp.GetSource<UserData>();
                    LoadStatu.text = "正在加载其他数据..";
                    StartCoroutine(Load());
                }
            });
        }, "GetUserData");
    }

    IEnumerator Load()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync("MainWD");
        yield return new WaitForEndOfFrame();
        op.allowSceneActivation = true;
    }

    public void StartShowAlertText() {
        AlertText.text = alertContents[Convert.ToInt32(UnityEngine.Random.Range(0, alertContents.Count))];
    }

    public override void OnDesconnected()
    {
        GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "提示", "与服务器连接已断开", null, true, () => {
            Application.Quit();
        });
    }

    public override void _Update()
    {
    }
}
