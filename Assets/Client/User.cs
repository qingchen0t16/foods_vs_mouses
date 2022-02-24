using FVMIO_From_Standard2_0.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Client
{
    public class User
    {
        private int userID;
        private UserData userData;

        public int UserID { get => userID; set => userID = value; }
        public UserData UserData { get => userData; set => userData = value; }
    }
}
