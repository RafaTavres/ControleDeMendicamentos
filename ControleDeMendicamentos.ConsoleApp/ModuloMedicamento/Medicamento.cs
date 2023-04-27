﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeMendicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleDeMendicamentos.ConsoleApp.ModuloMedicamento
{
    internal class Medicamento : EntidadeBase
    {
        public string nome { get; set; }
        public string descricao { get; set; }
        public int quantidadeDisponivel { get; set; }
        //public int quantidadeLimite { get; set; }
        public int quantidadeDeRetiradas { get; set; }
        public string bula { get; set; }
        public override void Atualizar(EntidadeBase entidadeAtualizada)
        {
            Medicamento medicamento = (Medicamento)entidadeAtualizada;
            nome = medicamento.nome;
            descricao = medicamento.descricao;
            quantidadeDisponivel = medicamento.quantidadeDisponivel;
            quantidadeDeRetiradas = medicamento.quantidadeDeRetiradas;
            bula = medicamento.bula;

        }

        public void RemoverQuantidade(int qtd)
        {
            this.quantidadeDisponivel -= qtd;
        }
        public void AumentarQuantidade(int qtd)
        {
            this.quantidadeDisponivel += qtd;
        }
    }
}
