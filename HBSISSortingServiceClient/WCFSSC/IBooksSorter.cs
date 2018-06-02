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
    [ServiceContract]
    public interface IBooksSorter
    {
        [OperationContract]
        [FaultContract(typeof(SortingServiceExceptionDetail))]
        Book[] GetBooksSorter(BooksOrder[] order);
    }

    /// <summary>
    /// Expection SortingServiceExceptionDetail - Classe serializada para trafegar no serviço por SOAP
    /// </summary>
    [DataContract]
    public class SortingServiceExceptionDetail
    {
        [DataMember]
        public string Message
        {
            get;
            set;
        }
    }
}
