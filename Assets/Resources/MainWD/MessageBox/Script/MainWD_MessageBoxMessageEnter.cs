using FVMIO_From_Standard2_0.Model;
using UnityEngine;
using UnityEngine.UI;

public class MainWD_MessageBoxMessageEnter : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return))
        {
            if (GetComponent<InputField>().text.Equals(string.Empty))
                return;
            MainWD_MessageBoxManager.instance.PushText(new SendMessage
            {
                Message = $"[123]:" + GetComponent<InputField>().text,
                SendType = "公众",
                Id = -1
            });
            
            /*ClientManager.Instance.Respones.Send(ClientManager.Instance.Request,SCPublic.SendType.Object,new SendMessage {
                Message = $"[{GameManager.Instance.User.UserData.UserName}]:" + GetComponent<InputField>().text,
                SendType = "公众",
                Id = -1
            },"Message");
            GetComponent<InputField>().text = "";*/
        }
    }
}
