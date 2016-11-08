using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal.Common
{
    public class ExceptionBase : Exception
    {
        public ExceptionBase()
            : base()
        {

        }

        public ExceptionBase(string message)
            : base(message)
        {
           // hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh
        }
    }
}
