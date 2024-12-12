using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class BomberoOcupadoException : Exception
    {
        public BomberoOcupadoException()
        {
        }

        public BomberoOcupadoException(string? message) : base(message)
        {
        }

        public BomberoOcupadoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
