using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp
{
    internal class EntidadeBase
    {
        public int id { get; set;}
        public virtual void Atualizar(EntidadeBase entidadeAtualizada)
        {
            id = entidadeAtualizada.id;
        }
    }
}
