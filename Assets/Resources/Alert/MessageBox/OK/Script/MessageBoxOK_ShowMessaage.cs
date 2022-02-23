using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBoxOK_ShowMessaage : MonoBehaviour
{
    // 获取各个组件
    private Text title;
    private Text content;
    private RectTransform message;
    private Action action;

    private void Awake()
    {
        title = transform.Find("Background/Title").GetComponent<Text>();
        content = transform.Find("Background/Content").GetComponent<Text>();
        message = transform.Find("Background").GetComponent<RectTransform>();
    }

    /// <summary>
    /// 初始化MessageBox
    /// </summary>
    /// <param name="size">大小</param>
    /// <param name="title">标题</param>
    /// <param name="content">内容</param>
    public MessageBoxOK_ShowMessaage Init(string title, string content, Vector2? size = null,bool close = true, Action action = null)
    {
        if (size is null)
            size = new Vector2(400, 240);
        if (!close) 
            Destroy(transform.Find("Background/Close").gameObject);
        message.sizeDelta = (Vector2)size;
        this.title.text = title;
        this.content.GetComponent<RectTransform>().sizeDelta = new Vector2(((Vector2)size).x - 20, ((Vector2)size).y - 55);
        this.content.text = content;
        this.action = action;
        return this;
    }

    public void Close() {
        action?.Invoke();
        Destroy(gameObject);
    }
}
