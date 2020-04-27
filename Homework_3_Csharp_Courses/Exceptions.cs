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
            public WrongFileException() : base("Вы загрузили неподдерживаемый формат файла.")
            {

            }
        }

        public class WrongKeyException : Exception
        {
            public WrongKeyException() : base("Вы не ввели ключ.")
            {

            }
        }
    }
}
