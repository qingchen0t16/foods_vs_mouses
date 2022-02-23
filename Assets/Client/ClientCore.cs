using SCPublic;
using SCPublic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Client
{
    internal class ClientManager :  IRequest
    {
        public bool Open = false;
        public static readonly ClientManager Instance = new ClientManager();

        /// <summary>
        /// 初始化
        /// </summary>
        public ClientManager() {
            Request = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  // 初始化Socket
        }

        /// <summary>
        /// 客户端核心初始化方法,直接用Instance单例访问
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public bool Init(string ip = "127.0.0.1", int port = 25565)
        {
            try
            {
                // 建立Socket 绑定IP端口
                Console.WriteLine("开始监听");
                ClientConnect(new IPEndPoint(IPAddress.Parse(ip), port));   // 连接服务器
            }
            catch (Exception ex)
            {
                // 无法连接至服务器
                Open = false;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 连接至服务器
        /// </summary>
        /// <param name="point"></param>
        public void ClientConnect(IPEndPoint point)
        {
            Request.Connect(point);
            Open = true;
            Request.BeginReceive(buff, 0, 1024, SocketFlags.None, new AsyncCallback(DataEnter), Request);  // 处理请求

        }

        public override void DataEnterEx(Exception ex)
        {
        }

        public override void PagePushFailed(byte[] buff)
        {
        }

        public override void Request_Close(string exMessage)
        {
        }

        public override void EndReceive(SourcePackage sp)
        {
            switch (sp.SendType) {
                case SendType.Object:
                    if (MainWD_MessageBoxManager.instance != null)
                        MainWD_MessageBoxManager.instance.PushText(sp.GetSource<SendMessage>());
                    break;
            }
        }
        /*public void ServerConn() {
            try
            {
                ClientManager.Instance.Respones.Send<UserLogin>(ClientManager.Instance.Request, SCPublic.SendType.Object, new UserLogin
                {
                    Account = account,
                    Password = password
                }, (sp) =>
                {
                    EventProcessor.QueueEvent(() =>
                    {
                        ms.Close();
                        GameManager.Instance.ShowMessageBox_OK(GameObject.Find("OpenGame/Manager").transform, "提示", sp.GetSource<string>());
                    });
                }, "Login");
            }
            catch (System.Exception)
            {
                ms.Close();
                GameManager.Instance.ShowMessageBox_OK(GameObject.Find("OpenGame/Manager").transform, "提示", "发送数据失败！与服务器连接已断开", null, false);
                ClientManager.Instance.Request.Close();
                Application.Quit();
            }
        }*/
    }
}
