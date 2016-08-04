using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Index_Calculator_ITLA.Model
{
    //TODO this class is expected to be used as a Entity, so is neccesary to divive the business logic
    //to another place
    class Quarter
    {
        public int Id { get; set; }

        public int No { get; set; }

        public ICollection<Selection> Selections { get; set; }

        //TODO limiting double result to two decimal places and round out depending of the third one
        public double QuaterIndexAverage {
            get
            {
                var totalCredits = 0;
                Selections.ToList().ForEach(e => totalCredits += e.Subject.Credits);

                return (double) TotalScore / totalCredits;
            }
        }

        private int TotalScore
        {
            get
            {
                var score = 0;
                Selections.ToList().ForEach(e => score += e.Score);
                return score;
            } 
        }

    }
}
