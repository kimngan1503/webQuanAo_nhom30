using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMDT_ver4.Common
{
    [Serializable]
    public class UserLogin
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
}