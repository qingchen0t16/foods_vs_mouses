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
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("OpenGame/Manager").transform, "��ʾ", "�������˺�");
            GetComponent<Button>().interactable = true;
            return;
        }
        if (password.Equals(string.Empty))
        {
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("OpenGame/Manager").transform, "��ʾ", "����������");
            GetComponent<Button>().interactable = true;
            return;
        }
        if (!new Regex(@"^([a-zA-Z0-9_]){4,}$").IsMatch(account) || !new Regex(@"^([a-zA-Z0-9_]){4,}$").IsMatch(password))
        {
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("OpenGame/Manager").transform, "��ʾ", "�˺����벻���Ϲ���(���ȴ���4 �� ��'A-Z','a-z'��'0-9'�� �»��� ��ɡ�)");
            GetComponent<Button>().interactable = true;
            return;
        }
        MessageBoxOK_ShowMessaage ms = GameManager.Instance.ShowMessageBox_OK(GameObject.Find("OpenGame/Manager").transform, "��ʾ", "���ڵ�¼��������", null, false);

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
                if (cmd[0] != "��¼�ɹ�")
                    GameManager.Instance.ShowMessageBox_OK(GameObject.Find("OpenGame/Manager").transform, "��ʾ", cmd[0]);
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
