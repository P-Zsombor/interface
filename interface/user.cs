using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @interface
{
    public class user
    {
        public static List<user> users = new List<user>();
        public string username { get; set; }
        public string password { get; set; }
        public int points { get; set; }
        public int id { get; set; }
    }
}
