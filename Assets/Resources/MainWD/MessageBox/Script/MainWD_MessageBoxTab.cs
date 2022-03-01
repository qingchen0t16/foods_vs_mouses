using Assets.Client;
using FVMIO_From_Standard2_0.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainWD_MessageBoxTab : MonoBehaviour, IPointerClickHandler
{
    public int TabIndex = 0;
    private bool isContent = false; // 是内容框并非是TabButton
    private Image heightImg;
    bool btm = false;   // 是否在最底下

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isContent)
            MainWD_MessageBoxManager.instance.SelectTabBar(TabIndex);
        else
        {
            StartCoroutine("ReloadLayout");
            if (btm)
                StartCoroutine("InsSrollBar");
        }
    }

    private void Start()
    {
        MainWD_MessageBoxManager.instance.tabAction += SelectBar;
        isContent = transform.GetComponent<Button>() is null;
        if (isContent)
        {
            Clear();
            if (TabIndex != 0)
            {
                transform.Find("Content").GetComponent<ScrollRect>().verticalNormalizedPosition = 0;
                transform.GetComponent<Image>().gameObject.SetActive(false);
            }
        }
        else
        {
            heightImg = transform.Find("Height").GetComponent<Image>();
            heightImg.gameObject.SetActive(false);
        }


    }

    // 刷新Layout
    IEnumerator ReloadLayout()
    {
        yield return new WaitForEndOfFrame();
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform.Find("Content/MessageGroup").GetComponent<RectTransform>());

    }

    // 滚动条到最底部
    IEnumerator InsSrollBar()
    {
        yield return new WaitForEndOfFrame();
        transform.Find("Scrollbar").GetComponent<Scrollbar>().value = 0;
    }

    /// <summary>
    /// Tab委托实现
    /// </summary>
    /// <param name="index"></param>
    public void SelectBar(int index)
    {
        if (!isContent)
        {
            GetComponent<Button>().interactable = index == TabIndex ? false : true;
            if (index == TabIndex)
                heightImg.gameObject.SetActive(false);
        }
        else
        {
            // 始终显示最后一行
            if (transform.Find("Content").GetComponent<ScrollRect>().verticalScrollbar.value >= 0.9)
                transform.Find("Content").GetComponent<ScrollRect>().verticalScrollbar.value = 0;
            transform.GetComponent<Image>().gameObject.SetActive(index == TabIndex ? true : false);
        }
    }

    // 清空文本
    public void Clear()
    {
        // 循环销毁全部gameobject
        for (int i = 0; i < transform.Find("Content/MessageGroup").childCount; i++)
            Destroy(transform.Find("Content/MessageGroup").GetChild(i).gameObject);
    }

    /// <summary>
    /// 增加消息
    /// </summary>
    [System.Obsolete]
    public void PushText(SendMessage data)
    {
        btm = transform.Find("Content").GetComponent<ScrollRect>().verticalScrollbar.value <= 0.1 || transform.Find("Content").GetComponent<ScrollRect>().verticalScrollbar.value >= 0.9;

        switch (data.SendType)
        {
            case "公众":
                SpanMessage().Init(data.Message);
                break;
            case "系统":
                SpanMessage().Init(data.Message, new Color(193, 61, 100, 100), true);
                break;
        }
        //transform.Find("Content/Text").GetComponent<Text>().text += $"{(transform.Find("Content/Text").GetComponent<Text>().text != "" ? "\n" : "")}{content}";


        if (btm && gameObject.active)
            StartCoroutine("InsSrollBar");
    }

    public MD_MessageObj_MainText SpanMessage() => Instantiate(Resources.Load<GameObject>("MainWD/MessageBox/MessageTextObj/MainText"), Vector3.zero, Quaternion.identity, transform.Find("Content/MessageGroup")).GetComponent<MD_MessageObj_MainText>();

    public void SetHeight(int index)
    {
        if (TabIndex != index)
            heightImg.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
