using System;
using System.Collections.Generic;
using System.Linq;
using hotel_dictionary.models;
using hotel_dictionary.services;

namespace hotel_dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Hotel hotel = new Hotel();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Hospedagem ===");
                Console.WriteLine("1. Cadastrar Hóspede");
                Console.WriteLine("2. Listar Hóspedes");
                Console.WriteLine("3. Listar Suítes");
                Console.WriteLine("4. Realizar Reserva");
                Console.WriteLine("5. Listar Reservas");
                Console.WriteLine("6. Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();
                Console.Clear();

                try
                {
                    switch (opcao)
                    {
                        case "1":
                            hotel.CadastrarHospede();
                            break;
                        case "2":
                            hotel.ListarHospedes();
                            break;
                        case "3":
                            hotel.ListarSuites();
                            break;
                        case "4":
                            hotel.RealizarReserva();
                            break;
                        case "5":
                            hotel.ListarReservas();
                            break;
                        case "6":
                            Console.WriteLine("Saindo...");
                            return;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro inesperado: {ex.Message}");
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}