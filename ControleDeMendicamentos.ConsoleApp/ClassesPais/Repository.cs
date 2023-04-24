using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ClassesPais
{
    internal class Repository
    {
        public int id = 1;
        public List<Entidade> listaEntidades = new List<Entidade>();
        public int IncrementaId()
        {
            return id++;
        }
        public void Inserir(Entidade entidade)
        {
            entidade.id = id;
            listaEntidades.Add(entidade);
            IncrementaId();
        }
        public void Atualizar(int id, Entidade entidade)
        {
            Entidade entidade2 = Busca(id);
            entidade2.Atualizar(entidade);
        }
        public Entidade Busca(int id)
        {
            Entidade entidade = null;
            foreach (Entidade a in listaEntidades)
            {
                if (a.id == id)
                {
                    entidade = a;
                    return entidade;
                }
            }
            return entidade;
        }
        public void Deletar(int id)
        {
            foreach (Entidade a in listaEntidades)
            {
                
                if (Busca(id).Equals(a))
                {
                    listaEntidades.Remove(a);
                    break;
                }
            }
        }
        public List<Entidade> RetornarTodos()
        {
            return listaEntidades;
        }
        
    }
}
