using UnityEngine;

public class SkyFireManager : MonoBehaviour
{
    // 预制体
    public GameObject Pf_Fire;

    /// <summary>
    /// 天空中生成火苗
    /// </summary>
    private void Sky_CreateFire() {
        Fire fire = GameObject.Instantiate<GameObject>(Pf_Fire, Vector3.zero, Quaternion.identity,transform).GetComponent<Fire>();
        fire.Sky_Init(Random.Range(-2.25F, 1.54F),new Vector3(Random.Range(-1.33F,3.45F), 3.45F,0));
    }

    // Start is called before the first frame update
    void Start()
    {
        Pf_Fire = Resources.Load<GameObject>("Game/Fire/Fire"); // 拿到火苗的预制体
        InvokeRepeating("Sky_CreateFire", 0F, 3F);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
