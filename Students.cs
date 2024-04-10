using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_de_test_3
{
    [Serializable]
    public class Students : IComparable<Students>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Grade { get; set; }
        
        public Students() { }

        public Students(int id, string name, double grade)
        {
            Id = id;
            Name = name;
            this.Grade = grade;
        }

        public int CompareTo(Students other)
        {
            return Id.CompareTo(other.Id);
        }
    }
}
