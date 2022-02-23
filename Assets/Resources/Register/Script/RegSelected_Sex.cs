using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RegSelected_Sex : MonoBehaviour,IPointerClickHandler
{
    private Image Top;
    private SpriteRenderer IsLand;
    private GameObject Light, StaticPeople, DynamicPeople;
    private bool selected = false;
    public bool IsMan = false;
    public bool Selected
    {
        get => selected; set
        {
            selected = value;
            if (selected) {
                Top.gameObject.SetActive(true);
                Light.gameObject.SetActive(true);
                StaticPeople.SetActive(false);
                DynamicPeople.SetActive(true);
            } else {
                Top.gameObject.SetActive(false);
                Light.gameObject.SetActive(false);
                StaticPeople.SetActive(true);
                DynamicPeople.SetActive(false);
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        RegManager.Instance.SetSelected(IsMan);
    }

    private void Awake()
    {
        // °ó¶¨×é¼þ
        Top = transform.Find("Top").GetComponent<Image>();
        IsLand = transform.Find("IsLand").GetComponent<SpriteRenderer>();
        Light = transform.Find("Light").gameObject;
        StaticPeople = transform.Find("Static").gameObject;
        DynamicPeople = transform.Find("Dynamic").gameObject;
        Top.gameObject.SetActive(false);
        Light.gameObject.SetActive(false);
        StaticPeople.SetActive(true);
        DynamicPeople.SetActive(false);
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
