using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Challenge___Order_Management_System.Exception
{
    internal class NoDataFoundException:ApplicationException
    {
        public NoDataFoundException() { }
        public NoDataFoundException(string message) : base(message)
        {
        }
    }
}
