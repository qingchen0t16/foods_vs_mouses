using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using Assets.Resources.Game.Food.Script;

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
    private bool wantPlace;  // 是否需要放置
    public bool WantPlace {
        get => wantPlace;
        set {
            wantPlace = value;
            if (wantPlace)
            {
                food = GameObject.Instantiate<GameObject>(FoodManager.Instance.GetFoodByType(FoodType.xiaohuolu), Vector3.zero, Quaternion.identity, GameObject.Find("Game/GridManager").transform);
            }
            else
            {
                if (food is null)
                    return;
                Destroy(food.gameObject);
                food = null;
            }
        }
    }
    private GameObject food;    // 创建的植物
    private GameObject gridFood;    // 网格中透明的植物

    private void Start()
    {
        maskImg = transform.Find("Mask").GetComponent<Image>();
        CanPlace = false;
        //WantPlace = false;
    }

    private void Update()
    {
        if (WantPlace && food != null)
        {
            // 放置食物状态,欲放置食物不为空
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            food.transform.position = new Vector3(mousePoint.x, mousePoint.y,0);
        }
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
        if (!WantPlace)
            WantPlace = true;

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
