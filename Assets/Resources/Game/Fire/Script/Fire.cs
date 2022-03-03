using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Fire : MonoBehaviour
{
    public float TargetDownY;   // ����Ŀ���
    public bool IsSky = false;
    public bool IsActive = false;

    /// <summary>
    /// �������ϵ�����
    /// </summary>
    public void Sky_Init(float targetDownY, Vector3 spanPos)
    {
        IsSky = true;
        TargetDownY = targetDownY;
        transform.position = spanPos;
    }

    private void Start()
    {
    }

    /// <summary>
    /// ����
    /// </summary>
    private void Update()
    {
        if (IsActive)   // �ѱ�����
            return;
        if (IsSky)  // �������ϵĻ���
        {
            if (transform.position.y <= TargetDownY)
            {
                Done();
                return;
            }
            transform.Translate(Vector3.down * Time.deltaTime);
        }
        else
            return;
    }

    /// <summary>
    /// ������
    /// </summary>
    private void OnMouseEnter()
    {
        // ������ڵ�,������Ӧ
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        Active();
    }

    /// <summary>
    /// ����CardBar
    /// </summary>
    private void FlyAn(Vector3 pos)
    {
        StartCoroutine(DoFly(pos));
    }
    private IEnumerator DoFly(Vector3 pos)
    {
        Vector3 direction = (pos - transform.position).normalized;  // ��ó���Ϊ1�ķ���
        while (Vector3.Distance(pos, transform.position) > 0.5F)
        {
            yield return new WaitForSeconds(0.02F);
            transform.Translate(direction);
        }
        Destroy();
    }

    /// <summary>
    /// ����������Ķ���
    /// </summary>
    public void JumpAn()
    {
        StartCoroutine(DoJump());
    }
    private IEnumerator DoJump()
    {
        bool isLeft = Random.Range(0, 2) == 0;
        Vector3 startPos = transform.position;
        float x = isLeft ? -0.01F : 0.01F;
        while (transform.position.y <= startPos.y + 0.5F)
        {
            yield return new WaitForSeconds(0.005F);
            transform.Translate(new Vector3(x, 0.05F, 0));
        }
        while (transform.position.y >= startPos.y - 0.4F)
        {
            yield return new WaitForSeconds(0.005F);
            transform.Translate(new Vector3(x, -0.05F, 0));
        }
        Done();
    }

    /// <summary>
    /// ����������� �����Զ�����
    /// </summary>
    private void Done() {
        if (GameingManager.Instance.IsAutoFire)
            Active();
        Invoke("Destroy", 5F);
    }

    /// <summary>
    /// ���类����
    /// </summary>
    private void Active()
    {
        IsActive = true;
        PlayerManager.Instance.FireNum += 25;
        FlyAn(UIManager.Instance.GetFirePos());
    }

    /// <summary>
    /// ��������
    /// </summary>
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
