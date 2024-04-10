using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_de_test_3
{
    [Serializable]
    internal class Facultate
    {
        public int Id { get; set; }

        public List<Students> Students { get; set; }

        public Facultate() { 
            Students = new List<Students>();
        }
        
    }
}
