using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class MyException : ApplicationException
    {

        public MyException() { }
        public MyException(string massage) : base(massage) { }
        public MyException(string message, Exception inner)
        : base(message, inner)
        { }
    }
}
