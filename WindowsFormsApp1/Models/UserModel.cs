using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    class UserModel
    {
        public static List<(string user, string roles)> get()
        {
            List<(string, string)> data = new List<(string, string)> { };
            string query = "SELECT * FROM ALL_USERS";

            return data;
        }
    }
}
