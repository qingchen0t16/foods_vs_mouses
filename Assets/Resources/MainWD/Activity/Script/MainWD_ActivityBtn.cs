using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainWD_ActivityBtn : MonoBehaviour,IPointerClickHandler
{
    public int Index = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        MainWD_ActivityManager.Instance.SetActivityContent(Index);
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
