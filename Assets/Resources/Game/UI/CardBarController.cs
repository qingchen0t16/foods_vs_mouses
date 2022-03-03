using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CardBarController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    private Image maskImg;  // ����
    public float CDTime;  // ��ȴʱ��
    private float currCDTime;    // ����ȴʱ��
    private bool canPlace;  // �Ƿ�ɷ���
    public bool CanPlace
    {
        get => canPlace;
        set
        {
            canPlace = value;
            if (!canPlace)
            {
                maskImg.fillAmount = 1;
                CDEnter();
            }
            else
            {
                maskImg.fillAmount = 0;
            }
        }
    }

    private void Start()
    {
        maskImg = transform.Find("Mask").GetComponent<Image>();
        CanPlace = false;
    }

    /// <summary>
    /// �������
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!CanPlace)
            return;
        transform.GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }

    /// <summary>
    /// ����Ƴ�
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!CanPlace)
            return;
        transform.GetComponent<Image>().color = new Color(0.9F, 0.9F, 0.9F, 1);
    }

    /// <summary>
    /// ��갴��
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!CanPlace)  // �޷�ʹ��ʱ
            return;
        print("123");

    }

    /// <summary>
    /// ����CD
    /// </summary>
    public void CDEnter()
    {
        StartCoroutine(CalCD());
    }
    private IEnumerator CalCD()
    {
        float calCD = 1 / CDTime * 0.1F;    // ���������Ƴ���
        currCDTime = CDTime;
        while (currCDTime > 0)
        {
            yield return new WaitForSeconds(0.1F);
            maskImg.fillAmount -= calCD;
            currCDTime -= 0.1F;
        }
        // ��ȴ����
        CanPlace = true;
    }

    
}
