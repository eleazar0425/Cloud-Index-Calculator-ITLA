using Cloud_Index_Calculator_ITLA.Model;
using System;
using System.Collections.Generic;

namespace Cloud_Index_Calculator_ITLA.Util
{
    class CalculatorUtil
    {
        public static double CalculateFullIndex(List<Quarter> quarters)
        {
            var totalScore = 0;
            var totalCredits = 0;

            quarters.ForEach(e => {
                totalScore += e.TotalScore;
                totalCredits += e.TotalCredits;
            });

            return Math.Round((double)totalScore / totalCredits, 2);
        }
    }
}
