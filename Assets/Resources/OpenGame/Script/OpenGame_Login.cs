using Assets.Client;
using FVMIO_From_Standard2_0.Enum;
using FVMIO_From_Standard2_0.Model;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenGame_Login : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (!GetComponent<Button>().interactable)
            return;
        GetComponent<Button>().interactable = false;
        string account = transform.parent.Find("Account").GetComponent<InputField>().text,
               password = transform.parent.Find("Password").GetComponent<InputField>().text;
        if (account.Equals(string.Empty))
        {
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("OpenGame/Manager").transform, "提示", "请输入账号");
            GetComponent<Button>().interactable = true;
            return;
        }
        if (password.Equals(string.Empty))
        {
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("OpenGame/Manager").transform, "提示", "请输入密码");
            GetComponent<Button>().interactable = true;
            return;
        }
        if (!new Regex(@"^([a-zA-Z0-9_]){4,}$").IsMatch(account) || !new Regex(@"^([a-zA-Z0-9_]){4,}$").IsMatch(password))
        {
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("OpenGame/Manager").transform, "提示", "账号密码不符合规则(长度大于4 且 由'A-Z','a-z'，'0-9'与 下划线 组成。)");
            GetComponent<Button>().interactable = true;
            return;
        }
        MessageBoxOK_ShowMessaage ms = GameManager.Instance.ShowMessageBox_OK(GameObject.Find("OpenGame/Manager").transform, "提示", "正在登录至服务器", null, false);

        ClientManager.Instance.Respones.Send<UserLogin>(ClientManager.Instance.Request, SendType.Object, new UserLogin
        {
            Account = account,
            Password = password
        }, (sp) =>
        {
            EventProcessor.QueueEvent(() =>
            {
                ms.Close();
                string[] cmd = sp.GetSource<string>().Split(',');
                if (cmd[0] != "登录成功")
                    GameManager.Instance.ShowMessageBox_OK(GameObject.Find("OpenGame/Manager").transform, "提示", cmd[0]);
                else
                {
                    GameManager.Instance.User.UserID = int.Parse(cmd[1]);
                    SceneManager.LoadScene("LoadWD");

                }
            });
        }, "Login");
    }


    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
