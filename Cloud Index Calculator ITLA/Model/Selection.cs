using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Index_Calculator_ITLA.Model
{
    //TODO this class is expected to be used as a Entity, so is neccesary to divive the business logic
    //to another place
    class Selection
    {
        public int Id { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Qualification Qualification { get; set; }

        public int Score {
            get
            {
                return Subject.Credits * Qualification.Value;
            }
        }
    }
}
