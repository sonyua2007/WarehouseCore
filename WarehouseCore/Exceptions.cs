using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseCore
{
    public class Exceptions : Exception
    {
        public Exceptions()
            : base("Сталася помилка")
        {
        }
        public Exceptions(string message)
            : base(message)
        {
        }
    }
}
