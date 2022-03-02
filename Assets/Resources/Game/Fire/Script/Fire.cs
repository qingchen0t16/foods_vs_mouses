using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float TargetDownY;   // ����Ŀ���
    public bool IsSky = false;

    /// <summary>
    /// �������ϵ�����
    /// </summary>
    public void Sky_Init(float targetDownY,Vector3 spanPos)
    {
        IsSky = true;
        TargetDownY = targetDownY;
        transform.position = spanPos;
    }

    /// <summary>
    /// ����
    /// </summary>
    private void Update()
    {
        if (IsSky) {    // �������ϵĻ���
            if (transform.position.y <= TargetDownY)
            {
                Invoke("Destroy", 5F);
                return;
            }
            transform.Translate(Vector3.down * Time.deltaTime);
        }
    }

    /// <summary>
    /// ��������
    /// </summary>
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
