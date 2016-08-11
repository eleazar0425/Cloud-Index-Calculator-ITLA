using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Index_Calculator_ITLA.Model
{
    public class Career
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public List<Subject> Subjets { get; set; }
    }
}
