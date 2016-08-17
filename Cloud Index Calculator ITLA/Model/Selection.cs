using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Index_Calculator_ITLA.Model
{
    public class Selection
    {
        public int Id { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Qualification Qualification { get; set; }

        public int Qualification_Id { get; set; }

        public int Subject_Id { get; set; }

        public int Quarter_Id { get; set; }

        /* The score represents one of the most important values in the process of calculating
         * the index. 
         *
         *       The formula is 
         *                  Index = SumScore / SumCredits
         *       where score = number of credits X the value of the letter (A=4, B=3, C=2, F=0)
         *       and SumScore is the sum of each individual subject score 
         *       and SumCredits the sum of credits
         */
        [NotMapped]
        public int Score {
            get
            {
                return Subject.Credits * Qualification.Value;
            }
        }
    }
}
