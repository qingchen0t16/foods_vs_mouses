using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MailBtn : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        MainWDManager.Instance.Scenes["EMail"].gameObject.SetActive(true);
    }
}
