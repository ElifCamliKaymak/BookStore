using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities.Exceptions
{
    public abstract class NotFound :Exception
    {
        //abstract bir sınıf olduğu için public olmasına gerek yok. protected olmalı
        protected NotFound(string message) : base(message)
        {
            
        }
        //sealed ile kalıtım verilmesi engellendi. bir nevi kısırlaştırıldı.
        public sealed class BookNotFound : NotFound
        {
            public BookNotFound(int id): base($"The book with id : {id} could not found.")
            {

            }
        }
    }
}
