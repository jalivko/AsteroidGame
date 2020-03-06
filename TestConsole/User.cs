using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class User
    {
        public string _Name { get; set; }

        private int _Age;

        public string Show()
        {
            return $"{_Name} {_Age}";
        }

        public User(string Name, int Age)
        {
            this._Name = Name;
            this._Age = Age;
        }
    }
}
