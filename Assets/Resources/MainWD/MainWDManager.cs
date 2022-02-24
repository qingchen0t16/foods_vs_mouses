using Assets.Client;
using FVMIO_From_Standard2_0.Enum;
using FVMIO_From_Standard2_0.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWDManager : ClientMonoBehaviour
{
    // 获取当前所有窗口
    public Dictionary<string,Transform> Scenes = new Dictionary<string, Transform>();

    // 单例
    public static MainWDManager Instance;

    private void Awake()
    {
        Instance = this;

        // 循环获取全部场景
        foreach (GameObject rootObj in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
        {
            if (rootObj.name.Equals("Manager") || rootObj.name.Equals("Main Camera") || rootObj.name.Equals("EventSystem"))
                continue;
            rootObj.SetActive(false);
            Scenes.Add(rootObj.name, rootObj.GetComponent<Transform>());
        }

        // 显示最初应该显示的界面
        Scenes["MainCity_UI"].gameObject.SetActive(true);
        Scenes["MainCity_Control"].gameObject.SetActive(true);
        Scenes["UserBox"].gameObject.SetActive(true);

    }

    /// <summary>
    /// 测试环境
    /// </summary>
    void TestSences() {
        print("连接服务器");
        ClientManager.Instance.Init("127.0.0.1", 25565);    // 连接到服务器

        GameManager.Instance = new GameManager();
        GameManager.Instance.User = new User();
        GameManager.Instance.User.UserID = 5;
        ClientManager.Instance.Respones.Send(ClientManager.Instance.Request, SendType.Text, GameManager.Instance.User.UserID.ToString(), (sp) =>
        {
            if (sp.GetSource<UserData>().UserID == -1)
                GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "提示", "无法获取玩家数据", null, true, () =>
                {
                    print("无法拿到玩家数据");
                    Application.Quit();
                });
            else
            {
                GameManager.Instance.User.UserData = sp.GetSource<UserData>();
                print("已获取到游戏数据");
                EventProcessor.QueueEvent(() =>
                {
                    UserBoxManager.Instance.PanelUpDate(GameManager.Instance.User.UserData);    // 刷新面板
                });
                
            }
        }, "GetUserData");
    }

    private void Start()
    {
        // 使用测试环境
        TestSences();
        
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
