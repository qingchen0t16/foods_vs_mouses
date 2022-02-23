using Assets.Client;
using SCPublic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OpenGame_Main : ClientMonoBehaviour, IPointerClickHandler
{
    private RectTransform BG;   // ����ͼʵ��
    private bool Active = false;
    private void Awake()
    {
        // ��ȡ����ͼʵ��
        BG = GetComponent<RectTransform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Active_OpenAn()
    {
        if(!Active)
            StartCoroutine(Active_DoOpen());
    }
    private IEnumerator Active_DoOpen()
    {
        Active = true;
        float speed = 0;
        while (Camera.main.WorldToScreenPoint(BG.position).y <= 481)
        {
            yield return new WaitForSeconds(0.001F);
            speed += 0.0005F;
            BG.Translate(new Vector3(0, 0.0005F + speed, 0));
        }
        while (Camera.main.WorldToScreenPoint(BG.position).y >= 420)
        {
            yield return new WaitForSeconds(0.001F);
            speed -= 0.002F;
            BG.Translate(new Vector3(0, -0.0005F - speed, 0));
        }
    }

    /// <summary>
    /// �ӽ�����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
            Active_OpenAn();
    }
    public bool IsTouchedUI() {
        if (Application.isMobilePlatform)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return true;
        } else if (EventSystem.current.IsPointerOverGameObject())
            return true;
        return false;
    }


    public override void OnDesconnected()
    {
        GameManager.Instance.ShowMessageBox_OK(GameObject.Find("OpenGame/Manager").transform, "��ʾ", "������������ѶϿ�", null, true, () => {
            Application.Quit();
        });
    }

    public override void _Update()
    {
    }
}
