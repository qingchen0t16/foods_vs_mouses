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
        // �����
        Instance = this;
        options = new List<RegSelected_Sex> ();
        options.Add (transform.Find("Man").GetComponent<RegSelected_Sex>());
        options.Add (transform.Find("WoMan").GetComponent<RegSelected_Sex>());
    }

    /// <summary>
    /// ���ص�¼����
    /// </summary>
    public void BackLoginWD() => SceneManager.LoadScene("OpenWD");

    /// <summary>
    /// ����ѡ��
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
        GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "��ʾ", "������������ѶϿ�", null, true, () => {
            Application.Quit();
        });
    }

    public override void _Update()
    {
        
    }
}
