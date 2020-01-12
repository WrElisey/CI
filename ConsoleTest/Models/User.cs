using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Models
{
    public class User
    {
        public string email { get; set; }

        public User(string email)
        {
            this.email = email;
        }
    }
}
