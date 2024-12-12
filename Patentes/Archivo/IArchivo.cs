using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivo
{
    public interface IArchivo
    {
        bool Guardar(List<Patente> datos);
        List<Patente> Leer();
    }
}
