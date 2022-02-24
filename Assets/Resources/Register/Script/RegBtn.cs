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
    // ��ȡ���
    private Transform parentObj;
    private InputField nickName, account, password, rePassword;

    public void OnPointerClick(PointerEventData eventData)
    {
        GetComponent<Button>().interactable = false;
        if (!Regex.IsMatch(nickName.text, @"^[\u4E00-\u9FA5A-Za-z0-9_ؼ ]{2,16}$"))
        {
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "��ʾ", "�ǳƳ���Ϊ 2 - 16 �ַ� �� ֻ���� ����,��ĸ,���� �� �����ַ� ��ɡ�");
            GetComponent<Button>().interactable = true;
            return;
        }
        else if (!Regex.IsMatch(account.text, @"^[A-Za-z0-9_]{6,24}$"))
        {
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "��ʾ", "�˺ų���Ϊ 6 - 24 �ַ� �� ֻ���� ��ĸ,���� �� '_' ��ɡ�");
            GetComponent<Button>().interactable = true;
            return;
        }
        else if (!Regex.IsMatch(password.text, @"^[A-Za-z0-9_]{6,24}$"))
        {
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "��ʾ", "���볤��Ϊ 6 - 24 �ַ� �� ֻ���� ��ĸ,���� �� '_' ��ɡ�");
            GetComponent<Button>().interactable = true;
            return;
        }
        else if (password.text == account.text)
        {
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "��ʾ", "���ڰ�ȫ����,�˺� �� ���벻����ͬ");
            GetComponent<Button>().interactable = true;
            return;
        }
        else if (password.text != rePassword.text)
        {
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "��ʾ", "�趨������ڶ�����������벻��ͬ");
            GetComponent<Button>().interactable = true;
            return;
        }
        else if (password.text != rePassword.text && password.text == account.text)
        {
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "��ʾ", "�趨������ڶ�����������벻��ͬ�����˺� �� ������ͬ,�������������𣿣�");
            GetComponent<Button>().interactable = true;
            return;
        }

        MessageBoxOK_ShowMessaage ms = GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "��ʾ", "����ע��...", null, false);
        try
        {
            ClientManager.Instance.Respones.Send<RegData>(ClientManager.Instance.Request, SendType.Object, new RegData
            {
                Account = account.text,
                NickName = nickName.text,
                Password = password.text,
                Sex = RegManager.Instance.IsMan ? "��" : "Ů"
            }, (sp) =>
            {
                EventProcessor.QueueEvent(() =>
                {
                    ms.Close();
                    GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "��ʾ", sp.GetSource<string>());
                    if (sp.GetSource<string>() == "ע��ɹ�")
                    {
                        // �ص���¼����
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
            GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "��ʾ", "��������ʧ�ܣ�������������ѶϿ�", null, false);
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
