using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Final
{
    public class UsuarioApellidoExistenteEventsArgs : EventArgs
    {
        public List<Usuario> usuariosRepetidos { get; set; }

        public UsuarioApellidoExistenteEventsArgs(List<Usuario> UsuariosRepetidos)
        {
            this.usuariosRepetidos = UsuariosRepetidos;
        }

    }
}
