using Cloud_Index_Calculator_ITLA.Model;
using Cloud_Index_Calculator_ITLA.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Index_Calculator_ITLA.Test
{
    class Test1
    {
        public static void Main()
        {
            var softwareDevelopment = new Career
            {
                Name = "Tecnología en Desarrollo de Software",
                ShortName = "TDS"
            };

            var careers = new List<Career>();
            careers.Add(softwareDevelopment);

            var subject1 = new Subject
            {
                Name = "Fundamento del computador",
                ShortName = "TI101",
                Credits = 4,
                Careers = careers
            };

            var subject2 = new Subject
            {
                Name = "Redaccion Castellana",
                ShortName = "ESP100",
                Credits = 4,
                Careers = careers
            };

            var subject3 = new Subject
            {
                Name = "Etica 1",
                ShortName = "FIL101",
                Credits = 3,
                Careers = careers
            };

            var A = new Qualification
            {
                Letter = "A",
                Value = 4
            };

            var B = new Qualification
            {
                Letter = "B",
                Value = 3
            };

            var C = new Qualification
            {
                Letter = "C",
                Value = 2
            };

            var F = new Qualification
            {
                Letter = "F",
                Value = 0
            };

            var selections = new List<Selection>();

            selections.Add(new Selection {
                Subject = subject1,
                Qualification = A
            });

            selections.Add(new Selection
            {
                Subject = subject2,
                Qualification = B
            });

            selections.Add(new Selection
            {
                Subject = subject3,
                Qualification = C
            });

            var firstQuater = new Quarter
            {
                No = 1,
                Selections = selections
            };

            var subject4 = new Subject
            {
                Name = "Precalculo",
                ShortName = "Calc11",
                Credits = 5,
                Careers = careers
            };

            var subject5 = new Subject
            {
                Name = "Introduccion a la base de datos",
                ShortName = "SOFT102",
                Credits = 4,
                Careers = careers
            };

            var subject6 = new Subject
            {
                Name = "Fundamentos de programacion",
                ShortName = "Calc11",
                Credits = 4,
                Careers = careers
            };

            var seleccions2 = new List<Selection>();
            seleccions2.Add(new Selection
            {
                Subject = subject4,
                Qualification = C
            });
            seleccions2.Add(new Selection
            {
                Subject = subject5,
                Qualification = A
            });
            seleccions2.Add(new Selection
            {
                Subject = subject6,
                Qualification = B
            });

            var secondQuarter = new Quarter
            {
                No = 2,
                Selections = seleccions2
            };

            var generalIndex = CalculatorUtil.CalculateFullIndex(new List<Quarter> {
                firstQuater,
                secondQuarter
            });

            Console.WriteLine("El indice cuatrimestral del C1 fue " + firstQuater.QuaterIndexAverage);

            Console.WriteLine("El indice cuatrimestral del C2 fue " + secondQuarter.QuaterIndexAverage);

            Console.WriteLine("El indice general fue " + generalIndex);

            Console.ReadKey();
        }
    }
}
