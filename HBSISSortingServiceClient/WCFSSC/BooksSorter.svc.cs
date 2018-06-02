using BusinessSSC;
using BusinessSSC.Exceptions;
using EntitySSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFSSC
{
    /// <summary>
    /// Implementação do Serviço SSC
    /// </summary>
    public class BooksSorter : IBooksSorter
    {
        public Book[] GetBooksSorter(BooksOrder[] order)
        {
            SorterHelper sorterHelper = new SorterHelper();
            Book[] booksOrdered = null;
            try
            {
                booksOrdered = sorterHelper.GetBooksSort(order);
            }
            catch (SortingServiceException ex)
            {
                SortingServiceExceptionDetail exceptionDetail = new SortingServiceExceptionDetail()
                {
                    Message = ex.Message
                };
                throw new FaultException<SortingServiceExceptionDetail>(exceptionDetail, new FaultReason(ex.Message));
            }
        
            return booksOrdered;
        }
    }
}
