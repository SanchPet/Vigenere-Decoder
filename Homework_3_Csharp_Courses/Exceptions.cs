using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_3_Csharp_Courses
{
    public class Exceptions
    {
        public static Exception CallExcepton(int option)
        {
            switch (option)
            {
                case (1):
                    return new WrongFileException();
                default:
                    return null;
            }
        }

        public class WrongFileException : Exception
        {
            public WrongFileException() : base("Вы загрузили неподдерживаемый формат файла.")
            {

            }
        }
    }
}
