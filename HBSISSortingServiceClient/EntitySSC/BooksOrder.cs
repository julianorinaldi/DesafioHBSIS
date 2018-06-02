using EntitySSC.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySSC
{
    /// <summary>
    /// Objeto que define o que deseja ordenar e em que direção
    /// </summary>
    public class BooksOrder
    {
        public OrderEnum OrderType { get; set; }
        public DirectionEnum DirectionType { get; set; }
    }
}
