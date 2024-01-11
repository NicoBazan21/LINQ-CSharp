using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = Student.TraerEstudiantes();
            List<Student> listDos = Student.TraerDosEstudiantes();


            Console.WriteLine("\nTraer todos");
            foreach (var item in LINQ.traerTodos(list))
                Console.WriteLine(item.FirstName + " " + item.Scores[0]);

            Console.WriteLine("\nTraer todos los nombres:");
            foreach (var item in LINQ.traerNombres(list))
                Console.WriteLine(item);

            Console.WriteLine("\nTraer a ALBE:");
            foreach (Student s in LINQ.traerNombres(list, "ALBE"))
                Console.WriteLine(s.FirstName);

            Console.WriteLine("\nTraer columnas:");
            foreach (Student s in LINQ.traerColumnas(list))
                Console.WriteLine(s.FirstName + " " + s.LastName);

            Console.WriteLine("\nOrdenar por nombre:");
            foreach (Student s in LINQ.ordernarPorNombre(list))
                Console.WriteLine(s.FirstName + " " + s.LastName);

            Console.WriteLine();
            Console.WriteLine("\nEmpieza con la C");
            foreach (Student s in LINQ.iniciaConLetra(list, "C"))
                Console.WriteLine(s.FirstName + " " + s.Scores[0]);

            Console.WriteLine("\nExtension de metodo ALBE:");
            foreach (Student s in LINQ.porColor(list, "ALBE"))
                Console.WriteLine(s.FirstName + " " + s.LastName);

            Console.WriteLine("\nPrimer item llamado ALBE o default:");

            Console.WriteLine(LINQ.primerItem(list).FirstName);

            Console.WriteLine("\nObtener primeros dos:");
            foreach (Student s in LINQ.primerosDos(list))
                Console.WriteLine(s.FirstName);

            /*
            Console.WriteLine("\nObtener rango dos al cuatro:\n");
            foreach(Student s in LINQ.rangoDosAlCuatro(list))
                Console.WriteLine(s.FirstName);*/

            Console.WriteLine("\nObtener distintos:");
            foreach (string s in LINQ.distintos(list))
                Console.WriteLine(s);

            Console.WriteLine("\nPagaron todos ALL:");
            Console.WriteLine(LINQ.PagosAll(list));

            Console.WriteLine("\nAlguno no Pago? ANY:");
            Console.WriteLine(LINQ.PagoAny(list));

            Console.WriteLine("\nContiene 21? Contains:");
            foreach (Student s in list)
                Console.WriteLine(s.FirstName + " " + LINQ.hay21Contains(s.Scores));

            Console.WriteLine("\nComparar Scores:");
            Console.WriteLine(LINQ.verificarSequenceEqual(LINQ.primerItem(list).Scores, LINQ.ultimoItem(list).Scores));

            Console.WriteLine("\nExcept Scores:");
            foreach (int item in LINQ.diferentesEnteros(LINQ.primerItem(list).Scores, LINQ.ultimoItem(list).Scores))
                Console.WriteLine(item);

            int[] aux = LINQ.primerItem(list).Scores;
            int[] auxDos = LINQ.ultimoItem(list).Scores;

            Console.WriteLine("\nIntersectar Scores:");
            foreach (int item in LINQ.interseccionEnteros(LINQ.primerItem(list).Scores, LINQ.ultimoItem(list).Scores))
                Console.WriteLine(item);

            Console.WriteLine("\nUnion Scores:");
            foreach (int item in LINQ.unionEnteros(LINQ.primerItem(list).Scores, LINQ.ultimoItem(list).Scores))
                Console.WriteLine(item);

            Console.WriteLine("\nConcatenar Scores:");
            foreach (int item in LINQ.concatEnteros(LINQ.primerItem(list).Scores, LINQ.ultimoItem(list).Scores))
                Console.WriteLine(item);

            Console.WriteLine("\nInner join listas:");
            foreach (var item in LINQ.innerJoinListas(list, listDos))
                Console.WriteLine(item.FirstName);

            Console.WriteLine("\nAgrupacion: ");
            LINQ.agruparPorDistintos(list);

            Console.WriteLine("\nAgrupacion por metodos: ");
            LINQ.agruparPorClaves(list);

            Console.WriteLine("\nContar todos (Count): ");
            Console.WriteLine(LINQ.contarTodos(list));

            Console.WriteLine("\nObtener minimo (min): ");
            Console.WriteLine(LINQ.obtenerMinimo(list));

            Console.WriteLine("\nInterseccion de listas");
            foreach (var item in LINQ.interseccionListas(list, listDos))
                Console.WriteLine(item);

            Console.WriteLine("\nExcept de listas");
            foreach (var item in LINQ.diferentesListas(list, listDos))
                Console.WriteLine(item);

            Console.WriteLine("\nAverage de Scores:");
            foreach (var item in LINQ.obtenerPromedio(list))
                Console.WriteLine(item);

            Console.WriteLine("\nSuma de Scores:");
            foreach (var item in LINQ.obtenerSuma(list))
                Console.WriteLine(item);

            Console.WriteLine("\nPromedio de Scores:");
            foreach (var item in LINQ.obtenerSumaObjeto(list))
                Console.WriteLine(item.FirstName + " " + item.Scores[0]);

            Console.ReadLine();
        }
    }
}
