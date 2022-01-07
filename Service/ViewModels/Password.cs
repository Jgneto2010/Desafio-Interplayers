using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class Password
    {
        public Password(string password)
        {
            _password = password;
        }

        public string _password { get; private set; }
    }
}
