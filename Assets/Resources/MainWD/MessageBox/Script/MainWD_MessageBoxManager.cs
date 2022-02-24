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
    private int thisIndex = 0;  // ��ǰѡ�е�index

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
    /// TabBar��ѡ��
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
    /// �����ı����ݵ������
    /// </summary>
    /// <param name="data"></param>
    public void PushText(SendMessage data)
    {
        EventProcessor.QueueEvent(() =>
        {
            switch (data.SendType)
            {
                case "����":
                    Contents["����"].PushText(data);
                    Buttons["����"].SetHeight(thisIndex);
                    break;
                case "ϵͳ":
                    Contents["ϵͳ"].PushText(data);
                    Buttons["ϵͳ"].SetHeight(thisIndex);
                    Contents["����"].PushText(data);
                    Buttons["����"].SetHeight(thisIndex);
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
