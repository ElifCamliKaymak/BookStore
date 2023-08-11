using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities.Exceptions
{
    //sealed ile kalıtım verilmesi engellendi. bir nevi kısırlaştırıldı.
    public sealed class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(int id) : base($"The book with id : {id} could not found.")
        {

        }
    }
}
