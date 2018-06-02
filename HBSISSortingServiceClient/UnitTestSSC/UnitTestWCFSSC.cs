using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using UnitTestSSC.Comparer;
using UnitTestSSC.WCFBooksSorter;
using WCFSSC;

namespace UnitTestSSC
{
    [TestClass]
    public class UnitTestWCFSSC
    {
        #region Convert Objects Array
        private Book[] GetBooks()
        {
            var books = Array.ConvertAll<EntitySSC.Book, WCFBooksSorter.Book>(EntitySSC.BooksLoad.GetBooks(), ConvertBook);
            return books;
        }

        public static WCFBooksSorter.Book ConvertBook(EntitySSC.Book book)
        {
            return new Book()
                {
                    Id = book.Id,
                    Author = book.Author,
                    EditionYear = book.EditionYear,
                    Title = book.Title
                };
        }
        #endregion


        /// <summary>
        /// Order by Title ascending | Expceted: Books 3, 4, 1, 2
        /// </summary>
        [TestMethod]
        public void TestMethodWCFGetBooksSorterByTitleAscending()
        {
            #region Load Books List
            Book[] expectedBooks = GetBooks();
            #endregion

            #region Order Books By Title Ascending
            expectedBooks = expectedBooks.OrderBy(x => x.Title).ToArray();
            #endregion

            List<BooksOrder> orderList = new List<BooksOrder>();
            orderList.Add(new BooksOrder() { OrderType = OrderEnum.TITLE, DirectionType = DirectionEnum.ACENDING });


            BooksSorterClient WCFConsume = new BooksSorterClient();
            Book[] actualBooks = WCFConsume.GetBooksSorter(orderList.ToArray());

            CollectionAssert.AreEqual(expectedBooks, actualBooks, new BookComparer());
        }

        /// <summary>
        /// Order By Author ascending & Title descending | Expceted: Books 1, 4, 3, 2
        /// </summary>
        [TestMethod]
        public void TestMethodWCFGetBooksSorterByAuthorAscending_TitleDescending()
        {
            #region Load Books List
            Book[] expectedBooks = GetBooks();
            #endregion

            #region Order Books By Title Ascending
            expectedBooks = expectedBooks.OrderBy(x => x.Author).ThenByDescending(y => y.Title).ToArray();
            #endregion

            List<BooksOrder> orderList = new List<BooksOrder>();
            orderList.Add(new BooksOrder() { OrderType = OrderEnum.AUTHOR, DirectionType = DirectionEnum.ACENDING });
            orderList.Add(new BooksOrder() { OrderType = OrderEnum.TITLE, DirectionType = DirectionEnum.DESCENDING });


            BooksSorterClient WCFConsume = new BooksSorterClient();
            Book[] actualBooks = WCFConsume.GetBooksSorter(orderList.ToArray());

            CollectionAssert.AreEqual(expectedBooks, actualBooks, new BookComparer());
        }

        /// <summary>
        /// Order By Edition descending & Author descending & Title ascending | Expceted: Books 4, 1, 3, 2
        /// </summary>
        [TestMethod]
        public void TestMethodWCFGetBooksSorterByEditiondescending_Authordescending_Titleascending()
        {
            #region Load Books List
            Book[] expectedBooks = GetBooks();
            #endregion

            #region Order Books By Title Ascending
            expectedBooks = expectedBooks.OrderByDescending(x => x.EditionYear).ThenByDescending(x => x.Author).ThenBy(y => y.Title).ToArray();
            #endregion

            List<BooksOrder> orderList = new List<BooksOrder>();
            orderList.Add(new BooksOrder() { OrderType = OrderEnum.EDITION, DirectionType = DirectionEnum.DESCENDING });
            orderList.Add(new BooksOrder() { OrderType = OrderEnum.AUTHOR, DirectionType = DirectionEnum.DESCENDING });
            orderList.Add(new BooksOrder() { OrderType = OrderEnum.TITLE, DirectionType = DirectionEnum.ACENDING });


            BooksSorterClient WCFConsume = new BooksSorterClient();
            Book[] actualBooks = WCFConsume.GetBooksSorter(orderList.ToArray());

            CollectionAssert.AreEqual(expectedBooks, actualBooks, new BookComparer());
        }

        /// <summary>
        /// Order By Null | Expceted: Throw Exception
        /// </summary>
        [TestMethod]
        public void TestMethodWCFGetBooksSorterByOrderNull()
        {
            bool testPassed = false;

            BooksSorterClient WCFConsume = new BooksSorterClient();
            try
            {
                BooksOrder[] orderList = null;
                Book[] actualBooks = WCFConsume.GetBooksSorter(orderList);
            }
            catch (FaultException ex)
            {
                testPassed = (ex.Message == @"Object ""order"" is Null");
            }

            Assert.IsTrue(testPassed);
        }

        /// <summary>
        /// Order By (empty set) | Expceted: (empty set)
        /// </summary>
        [TestMethod]
        public void TestMethodWCFGetBooksSorterByEmpty()
        {
            Book[] expectedBooks = { };
            BooksSorterClient WCFConsume = new BooksSorterClient();

            BooksOrder[] orderList = { };
            Book[] actualBooks = WCFConsume.GetBooksSorter(orderList);

            CollectionAssert.AreEqual(expectedBooks, actualBooks);
        }
    }
}
