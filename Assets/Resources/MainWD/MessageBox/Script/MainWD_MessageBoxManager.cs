using Assets.Client;
using FVMIO_From_Standard2_0.Model;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainWD_MessageBoxManager : MonoBehaviour
{
    public static MainWD_MessageBoxManager instance;
    public UnityAction<int> tabAction;
    public Dictionary<string, MainWD_MessageBoxTab> Contents = new Dictionary<string, MainWD_MessageBoxTab>();
    public Dictionary<string, MainWD_MessageBoxTab> Buttons = new Dictionary<string, MainWD_MessageBoxTab>();
    private int thisIndex = 0;  // 当前选中的index

    private void Awake()
    {
        instance = this;
        for (int i = 0; i < transform.Find("MessageBox/TabBar").childCount; i++)
        {
            Contents.Add(transform.Find("MessageBox/TabBar").GetChild(i).Find("Text").GetComponent<Text>().text, transform.Find("MessageBox/MessageContent").GetChild(i).GetComponent<MainWD_MessageBoxTab>());
            Buttons.Add(transform.Find("MessageBox/TabBar").GetChild(i).Find("Text").GetComponent<Text>().text, transform.Find("MessageBox/TabBar").GetChild(i).GetComponent<MainWD_MessageBoxTab>());
        }
    }

    private void Start()
    {
    }

    /// <summary>
    /// TabBar被选择
    /// </summary>
    /// <param name="index"></param>
    public void SelectTabBar(int index)
    {
        if (tabAction != null)
        {
            tabAction(index);
            thisIndex = index;
        }
    }

    /// <summary>
    /// 发送文本数据到聊天框
    /// </summary>
    /// <param name="data"></param>
    public void PushText(SendMessage data)
    {
        EventProcessor.QueueEvent(() =>
        {
            switch (data.SendType)
            {
                case "公众":
                    Contents["公众"].PushText(data);
                    Buttons["公众"].SetHeight(thisIndex);
                    break;
                case "系统":
                    Contents["系统"].PushText(data);
                    Buttons["系统"].SetHeight(thisIndex);
                    Contents["公众"].PushText(data);
                    Buttons["公众"].SetHeight(thisIndex);
                    break;
            }
        });
    }
    public void PushText(string type, string content)
    {
        if (Contents.ContainsKey(type))
        {
            Contents[type].PushText(new SendMessage
            {
                Id = -1,
                Message = content,
                SendType = type
            });
            Buttons[type].SetHeight(thisIndex);
        }

    }
}
