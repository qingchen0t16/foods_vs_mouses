using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float TargetDownY;   // 下落目标点
    public bool IsSky = false;

    /// <summary>
    /// 来自天上的阳光
    /// </summary>
    public void Sky_Init(float targetDownY,Vector3 spanPos)
    {
        IsSky = true;
        TargetDownY = targetDownY;
        transform.position = spanPos;
    }

    /// <summary>
    /// 更新
    /// </summary>
    private void Update()
    {
        if (IsSky) {    // 来自天上的火苗
            if (transform.position.y <= TargetDownY)
            {
                Invoke("Destroy", 5F);
                return;
            }
            transform.Translate(Vector3.down * Time.deltaTime);
        }
    }

    /// <summary>
    /// 销毁自身
    /// </summary>
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
