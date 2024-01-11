using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int[] Scores { get; set; }
        public bool Pago { get; set; }

        public static List<Student> TraerEstudiantes()
        {
            List<Student> list = new List<Student>();
            list.Add(
                new Student
                {
                    FirstName = "CLASSY",
                    LastName = "SHARON",
                    Scores = new int[] { 21, 76, 23, 59 },
                    Pago = true
                });
            list.Add(
               new Student
               {
                   FirstName = "RIYA",
                   LastName = "PAT",
                   Scores = new int[] { 24, 22, 41, 21 },
                   Pago = true
               });
            list.Add(
               new Student
               {
                   FirstName = "MONET",
                   LastName = "RITHIKA",
                   Scores = new int[] { 21, 90, 45, 46 },
                   Pago = true
               });
            list.Add(
               new Student
               {
                   FirstName = "ALBE",
                   LastName = "SILVIA",
                   Scores = new int[] { 43, 18, 25, 46 },
                   Pago = true
               });
            list.Add(
               new Student
               {
                   FirstName = "ALBE",
                   LastName = "BAZAN",
                   Scores = new int[] { 21, 18, 25, 46 },
                   Pago = true
               });
            return list;
        }

        public static List<Student> TraerDosEstudiantes()
        {
            List<Student> listDos = new List<Student>();
            listDos.Add(
                new Student
                {
                    FirstName = "CLASSY",
                    LastName = "SHARON",
                    Scores = new int[] { 21, 76, 23, 59 },
                    Pago = true
                });
            listDos.Add(
               new Student
               {
                   FirstName = "RIYA",
                   LastName = "PAT",
                   Scores = new int[] { 24, 22, 41, 21 },
                   Pago = true
               });
            return listDos;
        }
    }
}
