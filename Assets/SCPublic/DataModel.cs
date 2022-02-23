using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPublic
{
    /// <summary>
    /// 发送信息数据
    /// </summary>
    [Serializable]
    public class SendMessage
    {
        public string SendType; // 公众，私聊，公会
        public int Id;
        public string Message;
    }

    /// <summary>
    /// 登录请求数据
    /// </summary>
    [Serializable]
    public class UserLogin
    {
        public string Account;
        public string Password;
    }

    /// <summary>
    /// 注册请求数据
    /// </summary>
    [Serializable]
    public class RegData
    {
        public string NickName, Account, Password, Sex;
    }

    /// <summary>
    /// 用户的基本资料数据
    /// </summary>
    [Serializable]
    public class UserData
    {
        public int UserID;
        public string Account, UserName, Sex;
        public int Level;
        public long Exp;
        public UserMoneyData Money;
    }

    /// <summary>
    /// 用户的货币数据
    /// </summary>
    [Serializable]
    public class UserMoneyData
    {
        public long GD, D, GB;
    }

    [Serializable]
    public class UserLevel
    {
        public int Level;
        public long Exp;
        public long NeedExp => (long)Math.Round(Level * 100.99F + (Level - 1) * 1024);
    }
}
