using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainWD_ActivityManager : MonoBehaviour
{
    public static MainWD_ActivityManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SetActivityContent(int index)
    {
        for (int i = 0; i < transform.Find("LeftBox/LeftList/Viewport/Content").childCount; i++)
        {
            transform.Find("LeftBox/LeftList/Viewport/Content").transform.GetChild(i).GetComponent<Button>().interactable = true;
            transform.Find("ContentBox").transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.Find("LeftBox/LeftList/Viewport/Content").transform.GetChild(index).GetComponent<Button>().interactable = false;
        transform.Find("ContentBox").transform.GetChild(index).gameObject.SetActive(true);
        transform.Find("Background/ActivityBG").GetComponent<Image>().sprite = Resources.Load<Sprite>("Data/ActivityBackgrounds/" + index);
    }
}
