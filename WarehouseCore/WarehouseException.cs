using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseCore
{
    public class WarehouseException : Exception
    {
        public WarehouseException()
            : base("Сталася помилка")
        {
        }
        public WarehouseException(string message)
            : base(message)
        {
        }
    }
}
