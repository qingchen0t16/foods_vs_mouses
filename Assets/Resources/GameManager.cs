using Assets.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // µ•¿˝
    public static GameManager Instance;
    // ≈‰÷√¡–±Ì
    public OR_Message MessageBox;
    public User User;

    private void Awake()
    {
        if (Instance is null)
        { 
            Instance = this;
            MessageBox = Resources.Load<OR_Message>("ObjRes/OR_Message");
            User = new User();
            DontDestroyOnLoad(gameObject);
        }
    }


    public MessageBoxOK_ShowMessaage ShowMessageBox_OK(Transform parent, string title, string content, Vector2? size = null, bool close = true,Action action = null)
    {
        return GameObject.Instantiate(GameManager.Instance.MessageBox.MessageBox_OK, Vector3.zero, Quaternion.identity, parent).GetComponent<MessageBoxOK_ShowMessaage>().Init(title, content, size, close,action);
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
