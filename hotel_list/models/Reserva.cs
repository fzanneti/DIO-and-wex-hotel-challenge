using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotel_list.services;

namespace hotel_list.models
{
    public class Reserva
    {
        public int Id { get; set; }
        public Hospede Hospede { get; set; }
        public Suite Suite { get; set; }
        public int Dias { get; set; }
        public decimal CustoTotal { get; set; }

        public Reserva(int id, Hospede hospede, Suite suite, int dias)
        {
            Id = id;
            Hospede = hospede;
            Suite = suite;
            Dias = dias;
            CustoTotal = CalcularCusto();
            Suite.Disponivel = false;
        }

        public decimal CalcularCusto()
        {
            decimal custo = Dias * Suite.PrecoDiaria;
            if (Dias >= 10)
                CustoTotal *= 0.9m; // Aplica 10% de desconto
            return custo;
        }

        public override string ToString()
        {
            return $"Reserva ID: {Id}, Hóspede: {Hospede.Nome} {Hospede.Sobrenome}, Suíte: {Suite.Nome}, Dias: {Dias}, Custo: R${CustoTotal:F2}";
        }
    }
}