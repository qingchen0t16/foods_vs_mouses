using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Client;
using FVMIO_From_Standard2_0.Enum;

/// <summary>
/// ��������ǳ�
/// </summary>
public class RegRandomNickName : MonoBehaviour,IPointerClickHandler
{

    private InputField NickName;

    public void OnPointerClick(PointerEventData eventData)
    {
        MessageBoxOK_ShowMessaage ms = GameManager.Instance.ShowMessageBox_OK(GameObject.Find("Manager").transform, "��ʾ", "�ȴ���������Ӧ", null, false);

        ClientManager.Instance.Respones.Send<string>(ClientManager.Instance.Request, SendType.Text, RegManager.Instance.IsMan ? "��" : "Ů", (sp) =>
        {
            EventProcessor.QueueEvent(() =>
            {
                ms.Close();
                Debug.Log(sp.GetSource<string>());
                NickName.text = sp.GetSource<string>();
            });
        }, "GetRandomName");
    }

    private void Awake()
    {
        NickName = transform.parent.Find("Input").GetComponent<InputField>();
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
