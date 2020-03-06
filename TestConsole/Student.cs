using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Student
    {
        public string Name { get; set; }

        public List<int> Raitings { get; set; } = new List<int>();

        public double AverageRaiting => Raitings.Average();

        public override string ToString() => $"{Name}: {AverageRaiting:0.##}";
    }
}
