﻿using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using ControleDeMendicamentos.ConsoleApp.ModuleFornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuloMedicamento
{
    internal class MedicamentoRepository : RepositoryBase
    {

        public List<Medicamento> listaDeMedicamentos = new List<Medicamento>();
        public override Medicamento Busca(int id)
        {
            return (Medicamento)base.Busca(id);
        }
        public List<Medicamento> RetornarTodosOrdenadosQuantidadeDisponivel()
        {
            List<Medicamento> objetoOrdenados = listaDeMedicamentos.OrderBy(x => x.quantidadeDisponivel).ToList();
            return objetoOrdenados;
        }
        public List<Medicamento> RetornarTodosOrdenadosPorRetirada()
        {
            List<Medicamento> objetoOrdenados = listaDeMedicamentos.OrderByDescending(x => x.quantidadeDeRetiradas).ToList();
            return objetoOrdenados;
        }

    }
}
