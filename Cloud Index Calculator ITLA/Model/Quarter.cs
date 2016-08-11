using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Index_Calculator_ITLA.Model
{
    public class Quarter
    {
        public int Id { get; set; }

        public int No { get; set; }

        public List<Selection> Selections { get; set; }

        [NotMapped]
        public double QuaterIndexAverage {
            get
            {
                var totalCredits = 0;
                Selections.ToList().ForEach(e => totalCredits += e.Subject.Credits);

                return Math.Round((double) TotalScore / totalCredits, 2);
            }
        }

        [NotMapped]
        public int TotalScore
        {
            get
            {
                var score = 0;
                Selections.ToList().ForEach(e => score += e.Score);
                return score;
            } 
        }

        [NotMapped]
        public int TotalCredits
        {
            get
            {
                var credits = 0;
                Selections.ToList().ForEach(e => credits += e.Subject.Credits);
                return credits;
            }
        }
    }
}
