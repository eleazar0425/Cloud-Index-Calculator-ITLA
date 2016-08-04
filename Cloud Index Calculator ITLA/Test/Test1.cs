using Cloud_Index_Calculator_ITLA.Model;
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
                Letter = 'A',
                Value = 4
            };

            var B = new Qualification
            {
                Letter = 'B',
                Value = 3
            };

            var C = new Qualification
            {
                Letter = 'C',
                Value = 2
            };

            var F = new Qualification
            {
                Letter = 'F',
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

            Console.Write("El indice cuatrimestral fue " + firstQuater.QuaterIndexAverage);
            Console.ReadKey();
        }
    }
}
