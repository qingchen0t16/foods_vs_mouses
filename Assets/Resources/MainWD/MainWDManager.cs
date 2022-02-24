using Assets.Client;
using FVMIO_From_Standard2_0.Enum;
using FVMIO_From_Standard2_0.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWDManager : ClientMonoBehaviour
{
    // ��ȡ��ǰ���д���
    public Dictionary<string,Transform> Scenes = new Dictionary<string, Transform>();

    // ����
    public static MainWDManager Instance;

    private void Awake()
    {
        Instance = this;

        // ѭ����ȡȫ������
        foreach (GameObject rootObj in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
        {
            if (rootObj.name.Equals("Main Camera") || rootObj.name.Equals("EventSystem"))
                continue;
            rootObj.SetActive(false);
            Scenes.Add(rootObj.name, rootObj.GetComponent<Transform>());
        }

        // ��ʾ���Ӧ����ʾ�Ľ���
        Scenes["MainCity_UI"].gameObject.SetActive(true);
        Scenes["MainCity_Control"].gameObject.SetActive(true);
        Scenes["UserBox"].gameObject.SetActive(true);

        // ʹ�ò��Ի���
        TestSences();
    }

    /// <summary>
    /// ���Ի���
    /// </summary>
    void TestSences() {
        print("���ӷ�����");
        ClientManager.Instance.Init("127.0.0.1", 25565);    // ���ӵ�������

        GameManager.Instance = new GameManager();
        GameManager.Instance.User = new User();
        GameManager.Instance.User.UserID = 5;
        ClientManager.Instance.Respones.Send(ClientManager.Instance.Request, SendType.Text, GameManager.Instance.User.UserID.ToString(), (sp) =>
        {
            if (sp.GetSource<UserData>().UserID == -1)
                GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "��ʾ", "�޷���ȡ�������", null, true, () =>
                {
                    print("�޷��õ��������");
                    Application.Quit();
                });
            else
            {
                GameManager.Instance.User.UserData = sp.GetSource<UserData>();
                print("�ѻ�ȡ����Ϸ����");
            }
        }, "GetUserData");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void _Update()
    {
    }

    public override void OnDesconnected()
    {
        GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "��ʾ", "������������ѶϿ�", null, true, () => {
            Application.Quit();
        });
    }
}
