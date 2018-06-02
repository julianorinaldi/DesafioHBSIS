using BusinessSSC.Exceptions;
using EntitySSC;
using EntitySSC.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessSSC
{
    public class SorterHelper
    {
        private Book[] booksInstance = EntitySSC.BooksLoad.GetBooks();

        /// <summary>
        /// Método de Validação da Ordenação
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Book[] GetBooksSort(BooksOrder[] order)
        {
            if (order == null)
                throw new SortingServiceException(@"Object ""order"" is Null");
            else if (order.Length == 0)
                return new Book[] { };

            IQueryable<Book> queryOrder = booksInstance.AsQueryable();

            return GetOrderBookList(queryOrder, order);
        }


        /// <summary>
        /// Método Genério para filtrar com LINQ
        /// </summary>
        /// <param name="queryOrder"></param>
        /// <param name="bookOrder"></param>
        /// <returns></returns>
        private static Book[] GetOrderBookList(IQueryable<Book> query, BooksOrder[] order)
        {
            IOrderedQueryable<Book> queryOrder = null;

            foreach (var bookOrder in order)
            {
                switch (bookOrder.OrderType)
                {
                    default:
                    case OrderEnum.TITLE:
                        switch (bookOrder.DirectionType)
                        {
                            case DirectionEnum.DESCENDING:
                                if (queryOrder == null)
                                    queryOrder = query.OrderByDescending(x => x.Title);
                                else
                                    queryOrder = queryOrder.ThenByDescending(x => x.Title);
                                break;
                            case DirectionEnum.ACENDING:
                            default:
                                if (queryOrder == null)
                                    queryOrder = query.OrderBy(x => x.Title);
                                else
                                    queryOrder = queryOrder.ThenBy(x => x.Title);
                                break;
                        }
                        break;
                    case OrderEnum.AUTHOR:
                        switch (bookOrder.DirectionType)
                        {
                            case DirectionEnum.DESCENDING:
                                if (queryOrder == null)
                                    queryOrder = query.OrderByDescending(x => x.Author);
                                else
                                    queryOrder = queryOrder.ThenByDescending(x => x.Author);
                                break;
                            case DirectionEnum.ACENDING:
                            default:
                                if (queryOrder == null)
                                    queryOrder = query.OrderBy(x => x.Author);
                                else
                                    queryOrder = queryOrder.ThenBy(x => x.Author);
                                break;
                        }
                        break;
                    case OrderEnum.EDITION:
                        switch (bookOrder.DirectionType)
                        {
                            case DirectionEnum.DESCENDING:
                                if (queryOrder == null)
                                    queryOrder = query.OrderByDescending(x => x.EditionYear);
                                else
                                    queryOrder = queryOrder.ThenByDescending(x => x.EditionYear);
                                break;
                            case DirectionEnum.ACENDING:
                            default:
                                if (queryOrder == null)
                                    queryOrder = query.OrderBy(x => x.EditionYear);
                                else
                                    queryOrder = queryOrder.ThenBy(x => x.EditionYear);
                                break;
                        }
                        break;
                }
            }

            return queryOrder.ToArray();
        }
    }
}

