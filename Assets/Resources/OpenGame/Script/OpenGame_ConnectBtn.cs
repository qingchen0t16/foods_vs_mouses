using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Assets.Client;
using System.Net;

public class OpenGame_ConnectBtn : MonoBehaviour, IPointerClickHandler
{
    private string ip;
    private int port;
    private Text statuText;
    // 按下事件
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!GetComponent<Button>().interactable)
            return;
        ip = transform.parent.Find("IP").GetComponent<InputField>().text == String.Empty ? "127.0.0.1" : Dns.GetHostByName(transform.parent.Find("IP").GetComponent<InputField>().text).AddressList[0].ToString();
        port = Convert.ToInt32(transform.parent.Find("Port").GetComponent<InputField>().text == String.Empty ? "25565" : transform.parent.Find("Port").GetComponent<InputField>().text);
        if (ClientManager.Instance.Init(ip, port))
        {
            statuText.color = Color.green;
            statuText.text = "连接成功";
            transform.parent.Find("LoginBtn").GetComponent<Button>().interactable = true;
            transform.parent.Find("RightContent/RegBtn").GetComponent<Button>().interactable = true;
            GetComponent<Button>().interactable = false;
            transform.parent.Find("IP").GetComponent<InputField>().interactable = false;
            transform.parent.Find("Port").GetComponent<InputField>().interactable = false;
        }
        else
        {
            statuText.color = Color.red;
            statuText.text = "无法连接";
        }
    }

    private void Awake()
    {
        statuText = transform.Find("StatuText").GetComponent<Text>();
        if (ClientManager.Instance.Request.Connected)
        {
            statuText.color = Color.green;
            statuText.text = "连接成功";
            transform.parent.Find("LoginBtn").GetComponent<Button>().interactable = true;
            transform.parent.Find("RightContent/RegBtn").GetComponent<Button>().interactable = true;
            GetComponent<Button>().interactable = false;
            transform.parent.Find("IP").GetComponent<InputField>().interactable = false;
            transform.parent.Find("Port").GetComponent<InputField>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
