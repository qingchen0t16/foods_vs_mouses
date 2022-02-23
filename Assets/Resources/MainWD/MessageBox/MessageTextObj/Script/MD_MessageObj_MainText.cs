using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MD_MessageObj_MainText : MonoBehaviour
{
    /// <summary>
    /// 初始化消息文本
    /// </summary>
    /// <param name="text"></param>
    /// <param name="textColor"></param>
    /// <param name="isRichText"></param>
    /// <param name="isOutLine"></param>
    /// <param name="OutLineColor"></param>
    public void Init(string text,Color? textColor = null,bool isRichText = false,bool isOutLine = false,Color? OutLineColor = null) {
        GetComponent<Text>().text = text;
        GetComponent<Text>().color = textColor ?? new Color(255,255,255,100);
        GetComponent<Text>().supportRichText = isRichText;
        if(isOutLine)
            GetComponent<Outline>().effectColor = OutLineColor ?? new Color(0,0,0,100);
    }
}
