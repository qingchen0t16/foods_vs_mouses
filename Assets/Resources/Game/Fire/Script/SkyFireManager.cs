using UnityEngine;

public class SkyFireManager : MonoBehaviour
{
    

    /// <summary>
    /// 天空中生成火苗
    /// </summary>
    private void Sky_CreateFire() {
        Fire fire = GameObject.Instantiate<GameObject>(GameingManager.Instance.GameingConf.Pf_Fire, Vector3.zero, Quaternion.identity,transform).GetComponent<Fire>();
        fire.Sky_Init(Random.Range(-2.25F, 1.54F),new Vector3(Random.Range(-1.33F,3.45F), 3.45F,0));
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Sky_CreateFire", 0F, 1F);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
