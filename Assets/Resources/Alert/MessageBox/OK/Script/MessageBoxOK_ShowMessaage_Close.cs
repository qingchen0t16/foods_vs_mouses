using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MessageBoxOK_ShowMessaage_Close : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        transform.parent.parent.GetComponent<MessageBoxOK_ShowMessaage>().Close();    // ������Ϸ����
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
