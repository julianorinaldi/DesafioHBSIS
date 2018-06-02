using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySSC
{
    /// <summary>
    /// Entidade Book
    /// </summary>
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int EditionYear { get; set; }

    }
}
