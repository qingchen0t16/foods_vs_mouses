using Assets.Client;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegManager : ClientMonoBehaviour
{
    public static RegManager Instance;
    private List<RegSelected_Sex> options;
    public bool IsMan = false;

    private void Awake()
    {
        // 绑定组件
        Instance = this;
        options = new List<RegSelected_Sex> ();
        options.Add (transform.Find("Man").GetComponent<RegSelected_Sex>());
        options.Add (transform.Find("WoMan").GetComponent<RegSelected_Sex>());
    }

    /// <summary>
    /// 返回登录界面
    /// </summary>
    public void BackLoginWD() => SceneManager.LoadScene("OpenWD");

    /// <summary>
    /// 设置选中
    /// </summary>
    /// <param name="isMan"></param>
    public void SetSelected(bool isMan) {
        options[0].Selected = isMan ? true : false;
        options[1].Selected = isMan ? false : true;
        IsMan = isMan;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetSelected(false);
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
