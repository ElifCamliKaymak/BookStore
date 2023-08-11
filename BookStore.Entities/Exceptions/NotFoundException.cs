using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities.Exceptions
{
    public abstract class NotFoundException :Exception
    {
        //abstract bir sınıf olduğu için public olmasına gerek yok. protected olmalı
        protected NotFoundException(string message) : base(message)
        {
            
        }

    }
}
