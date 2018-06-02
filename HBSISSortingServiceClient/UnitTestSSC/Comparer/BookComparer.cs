using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestSSC.WCFBooksSorter;

namespace UnitTestSSC.Comparer
{
    public class BookComparer : IComparer<Book>, IComparer
    {
        public int Compare(Book x, Book y)
        {
            return (x.Id.CompareTo(y.Id));
        }

        public int Compare(object x, object y)
        {
            Book castX = x as Book;
            Book castY = y as Book;

            if (castX == null || castY == null)
            {
                return 0;
            }

            return Compare(castX, castY);
        }

    }
}
