using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Index_Calculator_ITLA.Model
{
    class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public int Credits { get; set; }

        public ICollection<Career> Careers { get; set; }

    }
}
