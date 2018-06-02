using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessSSC.Exceptions
{
    /// <summary>
    /// Expection SortingServiceException - Camada de Negócios
    /// </summary>
    public class SortingServiceException : Exception
    {
        public SortingServiceException(string message)
            : base(message)
        {

        }
    }
}
