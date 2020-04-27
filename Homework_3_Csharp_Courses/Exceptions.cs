using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_3_Csharp_Courses
{
    public class Exceptions
    {


        public class WrongFileException : Exception
        {
            public WrongFileException() : base("You have downloaded an unsupported file format.")
            {

            }
        }

        public class WrongKeyException : Exception
        {
            public WrongKeyException() : base("Incorrect key.")
            {

            }
        }
    }
}
