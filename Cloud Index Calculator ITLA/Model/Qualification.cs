using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Index_Calculator_ITLA.Model
{
    public class Qualification
    {
        public int Id { get; set; }

        [StringLength(1)]
        public string Letter { get; set; }

        public int Value { get; set; }
    }
}
