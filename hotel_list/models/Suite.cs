using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotel_list.services;

namespace hotel_list.models
{
    public class Suite
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoDiaria { get; set; }
        public int Capacidade { get; set; }
        public bool Disponivel { get; set; }

        public Suite(int id, string nome, decimal precoDiaria, int capacidade)
        {
            Id = id;
            Nome = nome;
            PrecoDiaria = precoDiaria;
            Capacidade = capacidade;
            Disponivel = true;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Suíte: {Nome}, Preço: R$ {PrecoDiaria:F2}, Capacidade: {Capacidade}, Disponível: {(Disponivel ? "Sim" : "Não")}";
        }
    }
}