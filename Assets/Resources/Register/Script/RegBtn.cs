using Assets.Client;
using FVMIO_From_Standard2_0.Enum;
using FVMIO_From_Standard2_0.Model;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegBtn : MonoBehaviour, IPointerClickHandler
{
    // 获取组件
    private Transform parentObj;
    private InputField nickName, account, password, rePassword;

    public void OnPointerClick(PointerEventData eventData)
    {
        GetComponent<Button>().interactable = false;
        if (!Regex.IsMatch(nickName.text, @"^[\u4E00-\u9FA5A-Za-z0-9_丶 ]{2,16}$"))
        {
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "提示", "昵称长度为 2 - 16 字符 且 只能由 汉字,字母,数字 与 特殊字符 组成。");
            GetComponent<Button>().interactable = true;
            return;
        }
        else if (!Regex.IsMatch(account.text, @"^[A-Za-z0-9_]{6,24}$"))
        {
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "提示", "账号长度为 6 - 24 字符 且 只能由 字母,数字 与 '_' 组成。");
            GetComponent<Button>().interactable = true;
            return;
        }
        else if (!Regex.IsMatch(password.text, @"^[A-Za-z0-9_]{6,24}$"))
        {
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "提示", "密码长度为 6 - 24 字符 且 只能由 字母,数字 与 '_' 组成。");
            GetComponent<Button>().interactable = true;
            return;
        }
        else if (password.text == account.text)
        {
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "提示", "出于安全考虑,账号 与 密码不能相同");
            GetComponent<Button>().interactable = true;
            return;
        }
        else if (password.text != rePassword.text)
        {
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "提示", "设定密码与第二次输入的密码不相同");
            GetComponent<Button>().interactable = true;
            return;
        }
        else if (password.text != rePassword.text && password.text == account.text)
        {
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "提示", "设定密码与第二次输入的密码不相同但是账号 与 密码相同,你这是在玩我吗？？");
            GetComponent<Button>().interactable = true;
            return;
        }

        MessageBoxOK_ShowMessaage ms = GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "提示", "正在注册...", null, false);
        try
        {
            ClientManager.Instance.Respones.Send<RegData>(ClientManager.Instance.Request, SendType.Object, new RegData
            {
                Account = account.text,
                NickName = nickName.text,
                Password = password.text,
                Sex = RegManager.Instance.IsMan ? "男" : "女"
            }, (sp) =>
            {
                EventProcessor.QueueEvent(() =>
                {
                    ms.Close();
                    GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "提示", sp.GetSource<string>());
                    if (sp.GetSource<string>() == "注册成功")
                    {
                        // 回到登录界面
                        RegManager.Instance.Invoke("BackLoginWD", 2F);
                    }
                    else
                        GetComponent<Button>().interactable = true;
                });
            }, "Register");
        }
        catch (System.Exception)
        {
            ms.Close();
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "提示", "发送数据失败！与服务器连接已断开", null, false);
            ClientManager.Instance.Request.Close();
            Application.Quit();
        }
    }

    

    private void Awake()
    {
        parentObj = transform.parent.parent;
        nickName = parentObj.Find("NickName/Input").GetComponent<InputField>();
        account = parentObj.Find("Account/Input").GetComponent<InputField>();
        password = parentObj.Find("Password/Input").GetComponent<InputField>();
        rePassword = parentObj.Find("RePassword/Input").GetComponent<InputField>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
