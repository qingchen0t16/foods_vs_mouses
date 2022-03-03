using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Fire : MonoBehaviour
{
    public float TargetDownY;   // 下落目标点
    public bool IsSky = false;
    public bool IsActive = false;

    /// <summary>
    /// 来自天上的阳光
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
    /// 更新
    /// </summary>
    private void Update()
    {
        if (IsActive)   // 已被激活
            return;
        if (IsSky)  // 来自天上的火苗
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
    /// 鼠标进入
    /// </summary>
    private void OnMouseEnter()
    {
        // 如果被遮挡,不做反应
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        Active();
    }

    /// <summary>
    /// 飞向CardBar
    /// </summary>
    private void FlyAn(Vector3 pos)
    {
        StartCoroutine(DoFly(pos));
    }
    private IEnumerator DoFly(Vector3 pos)
    {
        Vector3 direction = (pos - transform.position).normalized;  // 获得长度为1的方向
        while (Vector3.Distance(pos, transform.position) > 0.5F)
        {
            yield return new WaitForSeconds(0.02F);
            transform.Translate(direction);
        }
        Destroy();
    }

    /// <summary>
    /// 产能类产出的动画
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
    /// 动画播放完毕 五秒自动销毁
    /// </summary>
    private void Done() {
        if (GameingManager.Instance.IsAutoFire)
            Active();
        Invoke("Destroy", 5F);
    }

    /// <summary>
    /// 火苗被激活
    /// </summary>
    private void Active()
    {
        IsActive = true;
        PlayerManager.Instance.FireNum += 25;
        FlyAn(UIManager.Instance.GetFirePos());
    }

    /// <summary>
    /// 销毁自身
    /// </summary>
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
