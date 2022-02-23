using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Client
{
    public abstract class ClientMonoBehaviour : MonoBehaviour
    {
        private void Update()
        {
            if (ClientManager.Instance.Open && !ClientManager.Instance.Request.Connected)
            {
                ClientManager.Instance.Open = false;
                OnDesconnected();
                return;
            }
            _Update();
        }

        /// <summary>
        /// 与服务器连接中断
        /// </summary>
        public abstract void OnDesconnected();

        /// <summary>
        /// 与 Update() 无异
        /// </summary>
        public abstract void _Update();
    }
}
