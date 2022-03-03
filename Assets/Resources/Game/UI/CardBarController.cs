using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CardBarController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    private Image maskImg;  // 遮罩
    public float CDTime;  // 冷却时间
    private float currCDTime;    // 已冷却时间
    private bool canPlace;  // 是否可放置
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
    /// 鼠标移入
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!CanPlace)
            return;
        transform.GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }

    /// <summary>
    /// 鼠标移出
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!CanPlace)
            return;
        transform.GetComponent<Image>().color = new Color(0.9F, 0.9F, 0.9F, 1);
    }

    /// <summary>
    /// 鼠标按下
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!CanPlace)  // 无法使用时
            return;
        print("123");

    }

    /// <summary>
    /// 进入CD
    /// </summary>
    public void CDEnter()
    {
        StartCoroutine(CalCD());
    }
    private IEnumerator CalCD()
    {
        float calCD = 1 / CDTime * 0.1F;    // 单次遮罩移除高
        currCDTime = CDTime;
        while (currCDTime > 0)
        {
            yield return new WaitForSeconds(0.1F);
            maskImg.fillAmount -= calCD;
            currCDTime -= 0.1F;
        }
        // 冷却结束
        CanPlace = true;
    }

    
}
