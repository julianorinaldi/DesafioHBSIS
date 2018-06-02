using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySSC
{
    /// <summary>
    /// Classe de Carregamento das Informação - Neste caso apenas está simulando um banco de dados.
    /// </summary>
    public class BooksLoad
    {
        public static Book[] GetBooks()
        {
            List<Book> BookList = new List<Book>();

            BookList.Add(new Book() { Id = 1, Title = "Java How to Program", Author = "Deitel & Deitel", EditionYear = 2007 });
            BookList.Add(new Book() { Id = 2, Title = "Patterns of Enterprise Application Architecture", Author = "Martin Fowler", EditionYear = 2002 });
            BookList.Add(new Book() { Id = 3, Title = "Head First Design Patterns", Author = "Elisabeth Freeman", EditionYear = 2004 });
            BookList.Add(new Book() { Id = 4, Title = "Internet & World Wide Web: How to Program", Author = "Deitel & Deitel", EditionYear = 2007 });

            return BookList.ToArray();
        }

    }
}
