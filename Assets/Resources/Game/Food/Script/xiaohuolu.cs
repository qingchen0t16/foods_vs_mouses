using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xiaohuolu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateFire",0F,5F);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateFire() {
        Fire fire = GameObject.Instantiate(GameingManager.Instance.GameingConf.Pf_Fire,transform.position,Quaternion.identity,transform).GetComponent<Fire>();
        fire.JumpAn();
    }
}
