using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotel_dictionary.services;     

namespace hotel_dictionary.models
{
    public class Hospede
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public Hospede(int id, string nome, string sobrenome)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome} {Sobrenome}";
        }
    }
}