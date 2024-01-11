using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public static class LINQ
    {
        /// <summary>
        /// Select itera sobre cada item de la lista
        /// </summary>
        /// <param name="list">Lista de Student</param>
        /// <returns>Lista de Student</returns>
        public static List<Student> traerTodos(List<Student> list)
            => list.Select(item => item).ToList();
        //(from Student item in list select item).ToList();

        /// <summary>
        /// Trae el primer nombre de cada item de la lista
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Lista de strings (nombres)</returns>
        public static List<string> traerNombres(List<Student> list)
            => list.Select(item => item.FirstName).ToList();
        //(from Student item in list select item.FirstName).ToList();

        /// <summary>
        /// Trae el objeto que matchea con el parametro
        /// </summary>
        /// <param name="list">Lista de Student</param>
        /// <param name="nombre">Nombre del item a buscar</param>
        /// <returns>Lista de Student</returns>
        public static List<Student> traerNombres(List<Student> list, string nombre)
            => list.Where(item => item.FirstName == nombre).ToList();
        //   (from Student item in list
        //    where item.FirstName == nombre
        //    select item).ToList();

        /// <summary>
        /// Trae solo las columnas que se le solicita, cuando se declaran como objeto
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<Student> traerColumnas(List<Student> list)
            => list.Select(item => new Student
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
            }).ToList();
        //=> (from Student item in list
        //    select new Student
        //    {
        //        FirstName = item.FirstName,
        //        LastName = item.LastName
        //    }).ToList();

        /// <summary>
        /// OrderBy ordena por el atributo que se defina
        /// ThenByDescending ordena como segundo campo pero descendente
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<Student> ordernarPorNombre(List<Student> list)
            => list.OrderBy(item => item.FirstName)//ordena ascendente
                    .ThenByDescending(item => item.LastName)//ordena por segundo campo descendente
                    .ToList();
        //=> (from Student item in list
        //    orderby item.FirstName descending, item.LastName descending
        //    select item).ToList();

        /// <summary>
        /// Devuelve lista de Students que comiencen con la letra pasada por parametro 
        /// o que su primer Score sea mayor a 50
        /// </summary>
        /// <param name="list"></param>
        /// <param name="letra"></param>
        /// <returns></returns>
        public static List<Student> iniciaConLetra(List<Student> list, string letra)
            => list.Where(item => item.FirstName.StartsWith(letra) || item.Scores[0] > 50).ToList();
        //=> (from Student item in list
        //    where item.FirstName.StartsWith(letra) || item.Scores[0] > 50
        //    select item).ToList();

        /// <summary>
        /// Extension de ByColor
        /// </summary>
        /// <param name="query"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        private static IEnumerable<Student> ByColor(this IEnumerable<Student> query, string color)
            => query.Where(item => item.FirstName == color);
        //=> (from Student item in query
        //    where item.FirstName == color
        //    select item);

        /// <summary>
        /// Uso de ByColor, aunque esta extendido para que busque un nombre.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static List<Student> porColor(List<Student> list, string color)
            => list.Select(item => item).ByColor(color).ToList();
        //=> (from Student item in list select item).ByColor(color).ToList();

        /// <summary>
        /// Devuelve el primer match que encuentre, o devuelve lista Vacia.
        /// Diferencia con First y sus hermanos, que si no encuentran lanzan excepcion
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Student primerItem(List<Student> list)
            => list.FirstOrDefault(item => item.FirstName == "MONET");
        //=> (from Student item in list
        //    select item).FirstOrDefault(item => item.FirstName == "MONET"
        //  /*,
        //  new Student
        //  {
        //    FirstName = "NOT FOUND",
        //    LastName = "NOT FOUND",
        //  }*/
        //  );
        
        /// <summary>
        /// Igual que el de arriba
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Student ultimoItem(List<Student> list)
            => list.LastOrDefault(item => item.FirstName == "RIYA");
        //=> (from Student item in list
        //    select item).LastOrDefault(item => item.FirstName == "RIYA");

        /// <summary>
        /// Toma solo dos registros
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<Student> primerosDos(List<Student> list)
            => list.Take(2).ToList();
        //=> (from Student item in list
        //    select item).Take(2).ToList();

        /*public static List<Student> rangoDosAlCuatro(List<Student> list)
        => (from Student item in list
        select item).Take(2..4).ToList();*/

        /// <summary>
        /// Selecciona distintos segun la condicion dada
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<string> distintos(List<Student> list)
            => list.Select(item => item.FirstName).OrderBy(item => item).Distinct().ToList();
        //=> (from Student item in list
        //    orderby item.FirstName descending
        //    select item.FirstName).Distinct().ToList();

        /*public static List<Student> distintoss(List<Student> list)
        => (from Student item in list
        orderby item.FirstName descending
        select item).DistinctBy(s => s.FirstName).ToList();*/

        /*public static List<Student[]> chunkEstudiantes(List<Student> list)
        => (from Student item in list
        select item).Chunk(2).ToList();*/
        
        /// <summary>
        /// Devuelve true si el todos los registros cumplen la condicion
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Boolean PagosAll(List<Student> list)
            => list.All(s => s.Pago == true);
        //=> (from Student item in list
        //    select item).All(s => s.Pago == true);

        /// <summary>
        /// Devuelve true si algun registro cumple la condicion
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Boolean PagoAny(List<Student> list)
            => list.Any(s => s.Pago == false);
        //=> (from Student item in list
        //    select item).Any(s => s.Pago == false);

        /// <summary>
        /// Contiene si hay un numero 21
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Boolean hay21Contains(int[] list)
        => /*(from score in list
          select score).Contains(21);*/
            list.Contains(21);

        /// <summary>
        /// Verifica el orden/secuencialidad de los arrays
        /// </summary>
        /// <param name="list"></param>
        /// <param name="listDos"></param>
        /// <returns></returns>
        public static Boolean verificarSequenceEqual(int[] list, int[] listDos)
        => list.SequenceEqual(listDos);

        /// <summary>
        /// Lo mismo que el de arriba pero con objetos
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static Boolean verificarSequenceEqual(List<Student> list1, List<Student> list2)
        => list1.SequenceEqual(list2);

        /// <summary>
        /// Devuelve una lista de los registros que sean diferentes, como un outer join
        /// </summary>
        /// <param name="list"></param>
        /// <param name="listDos"></param>
        /// <returns></returns>
        public static List<int> diferentesEnteros(int[] list, int[] listDos)
        => list.Except(listDos).ToList();

        /// <summary>
        /// Lo mismo que el de arriba pero con los registros
        /// </summary>
        /// <param name="list"></param>
        /// <param name="listDos"></param>
        /// <returns></returns>
        public static List<string> diferentesListas(List<Student> list, List<Student> listDos)
            => list.Select(item => item.FirstName).Except(listDos.Select(item => item.FirstName)).ToList();
        //=> (from Student item in list
        //    select item.FirstName).Except((from Student item in listDos select item.FirstName)).ToList();

        /// <summary>
        /// Devuelve una lista con las intersecciones
        /// </summary>
        /// <param name="list"></param>
        /// <param name="listDos"></param>
        /// <returns></returns>
        public static List<int> interseccionEnteros(int[] list, int[] listDos)
        => list.Intersect(listDos).ToList();

        /// <summary>
        /// Devuelve listas con los objetos que cumplen la interseccion
        /// </summary>
        /// <param name="list"></param>
        /// <param name="listDos"></param>
        /// <returns></returns>
        public static List<string> interseccionListas(List<Student> list, List<Student> listDos)
            => list.Select(item => item.FirstName).Intersect(listDos.Select(item => item.FirstName)).ToList();
        //=> (from Student item in list
        //    select item.FirstName).Intersect((from Student item in listDos select item.FirstName)).ToList();

        /// <summary>
        /// UNION
        /// </summary>
        /// <param name="list"></param>
        /// <param name="listDos"></param>
        /// <returns></returns>
        public static List<int> unionEnteros(int[] list, int[] listDos)
        => list.Union(listDos).OrderBy(num => num).ToList();

        /*public static List<Student> unionListas(List<Student> list, List<Student> listDos)
        => (from Student item in list
        select item).UnionBy(listDos, p => p.FirstName).ToList();*/

        /// <summary>
        /// Concatena las listas
        /// </summary>
        /// <param name="list"></param>
        /// <param name="listDos"></param>
        /// <returns></returns>
        public static List<int> concatEnteros(int[] list, int[] listDos)
        => list.Concat(listDos).OrderBy(num => num).ToList();

        /// <summary>
        /// Inner Join
        /// </summary>
        /// <param name="list"></param>
        /// <param name="listDos"></param>
        /// <returns></returns>
        public static List<Student> innerJoinListas(List<Student> list, List<Student> listDos)
            => list.Join(listDos, item => item.FirstName,
                itemB => itemB.FirstName,
                (item, itemB) => new Student
                {
                    FirstName = item.FirstName,
                    LastName = itemB.LastName,
                    Scores = item.Scores,
                    Pago = item.Pago,
                }).ToList();
        //=> (from Student item in list
        //    join Student itemB in listDos
        //  on item.FirstName equals itemB.FirstName
        //    select new Student
        //    {
        //        FirstName = item.FirstName,
        //        LastName = itemB.LastName,
        //        Scores = itemB.Scores
        //    }).ToList();

        /// <summary>
        /// Ordena por nombre, y agrupa por apellido
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<IGrouping<string, Student>> agruparPorDistintos(List<Student> list)
            => list.OrderBy(p => p.FirstName).GroupBy(p => p.LastName).ToList();
        //=> (from item in list
        //    orderby item.FirstName
        //    group item by item.FirstName).ToList();

        /// <summary>
        /// Agrupa por las Keys
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<IGrouping<string, Student>> agruparPorClaves(List<Student> list)
        {
            List<IGrouping<string, Student>> lista = list.GroupBy(item => item.FirstName).OrderBy(item => item.Key).ToList();
            return lista;
        }
        //=> (from Student item in list
        //    group item by item.FirstName into nombres
        //    orderby nombres.Key
        //    select nombres).ToList();


        //public static List<Student> agruparAnidados(List<Student> list, List<Student> listDos)
        /*=> (from Student item in list 
            orderby item.FirstName 
            group item by item.LastName into nuevosEstudiantes
        select new Student { 
            LastName = nuevosEstudiantes.Key, 
            Student = (from Student itemB in listDos orderby itemB.FirstName
                    join item in list on itemB.FirstName equals item.FirstName
                    where itemB.FirstName == item.FirstName
                    select itemB).ToList()
        }).ToList();*/
        
        /// <summary>
        /// Funcion Count
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int contarTodos(List<Student> list)
            => list.Count(p => p.FirstName == "RIYA");
        //=> (from Student item in list
        //    where item.FirstName == "RIYA"
        //    select item).Count();

        /// <summary>
        /// Funcion min
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        //usar el MinBy devuelve el objeto
        public static int obtenerMinimo(List<Student> list)
            => list.Min(item => item.Scores.Min(itemB => itemB));
        //=> list.Min(p => p.Scores[0]);
        //=> (from Student item in list
        //select item.Scores[0]).Min();

        public static List<double> obtenerPromedio(List<Student> list)
            => list.Select(item => item.Scores.Average(itemB => itemB)).ToList();

        public static List<int> obtenerSuma(List<Student> list)
            => list.Select(item => item.Scores.Sum(itemB => itemB)).ToList();

        public static List<Student> obtenerSumaObjeto(List<Student> list)
            => list.Select(item => new Student
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                Scores = new int[] { item.Scores.Sum(itemB => itemB) },
            }).ToList();

        /*public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T,bool>) predicate)
        {
          foreach(var item in source)
          {
            if(predicate(item))
            {
              yield return item;
            }
          }
        }*/
    }
}
