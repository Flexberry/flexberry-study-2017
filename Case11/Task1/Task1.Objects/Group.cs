using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Objects
{
    public class Group
    {
        public GroupName name { get; }
        public double cost { get; }
        public Group(GroupName name, double cost)
        {
            this.name = name;
            this.cost = cost;
        }
    }
}
