using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotel_list.models; // Importa os modelos Hospede, Suite e Reserva

namespace hotel_list.services
{
    public class Hotel
    {
        private List<Hospede> hospedes;
        private List<Suite> suites;
        private List<Reserva> reservas;
        private int proximoIdHospede;
        private int proximoIdReserva;

        public Hotel()
        {
            hospedes = new List<Hospede>();
            suites = new List<Suite>();
            reservas = new List<Reserva>();
            proximoIdHospede = 1;
            proximoIdReserva = 1;
            InicializarSuites();
        }

        private void InicializarSuites()
        {
            suites.Add(new Suite(1, "Suíte Conforto", 450.00m, 2));
            suites.Add(new Suite(2, "Suíte Luxo", 780.00m, 3));
            suites.Add(new Suite(3, "Suíte Presidencial", 2500.00m, 4));
            suites.Add(new Suite(4, "Suíte Família", 950.00m, 5));
            suites.Add(new Suite(5, "Suíte Executiva", 620.00m, 2));
        }

         private void ExibirTabela(string[] cabecalhos, int[] tamanhosColunas, IEnumerable<string[]> linhas)
        {
            string linhaCabecalho = "|";
            for (int i = 0; i < cabecalhos.Length; i++)
            {
                linhaCabecalho += $" {cabecalhos[i].PadRight(tamanhosColunas[i])} |";
            }
            Console.WriteLine(linhaCabecalho);

            string separador = "+";
            for (int i = 0; i < tamanhosColunas.Length; i++)
            {
                separador += new string('-', tamanhosColunas[i] + 2) + "+";
            }
            Console.WriteLine(separador);

            foreach (var linha in linhas)
            {
                string linhaDados = "|";
                for (int i = 0; i < linha.Length; i++)
                {
                    linhaDados += $" {linha[i].PadRight(tamanhosColunas[i])} |";
                }
                Console.WriteLine(linhaDados);
            }

            Console.WriteLine(separador);
        }

        public void CadastrarHospede()
        {
            try
            {
                Console.Write("Digite o nome do hóspede: ");
                string nome = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nome))
                    throw new ArgumentException("Nome não pode ser vazio.");

                Console.Write("Digite o sobrenome do hóspede: ");
                string sobrenome = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(sobrenome))
                    throw new ArgumentException("Sobrenome não pode ser vazio.");

                Hospede hospede = new Hospede(proximoIdHospede, nome, sobrenome);
                hospedes.Add(hospede);
                Console.WriteLine($"Hóspede {nome} {sobrenome} cadastrado com ID {proximoIdHospede}.");
                proximoIdHospede++;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        }

        public void ListarHospedes()
        {   
            if (hospedes.Count == 0)
            {
                Console.WriteLine("Nenhum hóspede cadastrado.");
                return;
            }

            Console.WriteLine("\nLista de Hóspedes:");
            string[] cabecalhos = { "ID", "Nome", "Sobrenome" };
            int[] tamanhosColunas = { 5, 20, 20 };
            var linhas = hospedes.Select(h => new string[] { h.Id.ToString(), h.Nome, h.Sobrenome }).ToList();
            ExibirTabela(cabecalhos, tamanhosColunas, linhas);

            try
            {
                Console.Write("\nDeseja excluir um hóspede? Digite o ID ou 0 para voltar: ");
                if (int.TryParse(Console.ReadLine(), out int id) && id != 0)
                {
                    Hospede hospede = hospedes.Find(h => h.Id == id);
                    if (hospede == null)
                        throw new KeyNotFoundException("ID de hóspede não encontrado.");

                    if (reservas.Any(r => r.Hospede.Id == id))
                    {
                        Console.WriteLine("Não é possível excluir: hóspede possui reserva ativa.");
                        return;
                    }

                    hospedes.Remove(hospede);
                    Console.WriteLine("Hóspede excluído com sucesso.");
                }
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        }

        public void ListarSuites()
        {
            Console.WriteLine("\nLista de Suítes:");
            string[] cabecalhos = { "ID", "Nome", "Preço Diária", "Capacidade", "Disponível" };
            int[] tamanhosColunas = { 5, 20, 15, 10, 10 };
            var linhas = suites.Select(s => new string[] {
                s.Id.ToString(),
                s.Nome,
                $"R${s.PrecoDiaria:F2}",
                s.Capacidade.ToString(),
                s.Disponivel ? "Sim" : "Não"
            }).ToList();
            ExibirTabela(cabecalhos, tamanhosColunas, linhas);

            int disponiveis = suites.Count(s => s.Disponivel);
            int naoDisponiveis = suites.Count(s => !s.Disponivel);
            Console.WriteLine($"\nTotal de suítes disponíveis: {disponiveis}");
            Console.WriteLine($"Total de suítes não disponíveis: {naoDisponiveis}");
        }

        public void RealizarReserva()
        {
            try
            {
                if (hospedes.Count == 0)
                {
                    Console.WriteLine("Nenhum hóspede cadastrado. Cadastre um hóspede primeiro.");
                    return;
                }

                if (!suites.Any(s => s.Disponivel))
                {
                    Console.WriteLine("Nenhuma suíte disponível.");
                    return;
                }

                Console.WriteLine("\nHóspedes cadastrados:");
                string[] cabecalhosHospedes = { "ID", "Nome", "Sobrenome" };
                int[] tamanhosColunasHospedes = { 5, 20, 20 };
                var linhasHospedes = hospedes.Select(h => new string[] { h.Id.ToString(), h.Nome, h.Sobrenome }).ToList();
                ExibirTabela(cabecalhosHospedes, tamanhosColunasHospedes, linhasHospedes);

                Console.Write("Digite o ID do hóspede: ");
                if (!int.TryParse(Console.ReadLine(), out int idHospede))
                    throw new ArgumentException("ID de hóspede inválido.");

                Hospede hospedeSelecionado = hospedes.Find(h => h.Id == idHospede);
                if (hospedeSelecionado == null)
                    throw new KeyNotFoundException("ID de hóspede não encontrado.");

                Console.WriteLine("\nSuítes disponíveis:");
                string[] cabecalhosSuites = { "ID", "Nome", "Preço Diária", "Capacidade", "Disponível" };
                int[] tamanhosColunasSuites = { 5, 20, 15, 10, 10 };
                var linhasSuites = suites.Where(s => s.Disponivel).Select(s => new string[] {
                    s.Id.ToString(),
                    s.Nome,
                    $"R${s.PrecoDiaria:F2}",
                    s.Capacidade.ToString(),
                    s.Disponivel ? "Sim" : "Não"
                }).ToList();
                ExibirTabela(cabecalhosSuites, tamanhosColunasSuites, linhasSuites);

                // Modificado: Permite seleção por ID
                Console.Write("Digite o ID da suíte: ");
                if (!int.TryParse(Console.ReadLine(), out int idSuite))
                    throw new ArgumentException("ID da suíte inválido.");

                Suite suiteSelecionada = suites.Find(s => s.Id == idSuite && s.Disponivel);
                if (suiteSelecionada == null)
                    throw new KeyNotFoundException("Suíte inválida ou não disponível.");

                Console.Write("Digite o número de hóspedes na reserva: ");
                if (!int.TryParse(Console.ReadLine(), out int numPessoas) || numPessoas <= 0)
                    throw new ArgumentException("Número de hóspedes inválido.");

                if (numPessoas > suiteSelecionada.Capacidade)
                    throw new InvalidOperationException("Capacidade da suíte excedida.");

                Console.Write("Digite o número de dias: ");
                if (!int.TryParse(Console.ReadLine(), out int dias) || dias <= 0)
                    throw new ArgumentException("Número de dias inválido.");

                Reserva reserva = new Reserva(proximoIdReserva, hospedeSelecionado, suiteSelecionada, dias);
                reservas.Add(reserva);
                Console.WriteLine($"Reserva realizada com sucesso! Custo total: R${reserva.CustoTotal:F2}");
                proximoIdReserva++;
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        }

        public void ListarReservas()
        {
            if (reservas.Count == 0)
            {
                Console.WriteLine("Nenhuma reserva cadastrada.");
                return;
            }

            Console.WriteLine("\nLista de Reservas:");
            string[] cabecalhos = { "ID", "Hóspede", "Suíte", "Dias", "Custo Total" };
            int[] tamanhosColunas = { 5, 30, 20, 5, 15 };
            var linhas = reservas.Select(r => new string[] {
                r.Id.ToString(),
                $"{r.Hospede.Nome} {r.Hospede.Sobrenome}",
                r.Suite.Nome,
                r.Dias.ToString(),
                $"R${r.CustoTotal:F2}"
            }).ToList();
            ExibirTabela(cabecalhos, tamanhosColunas, linhas);

            try
            {
                Console.Write("\nDeseja encerrar uma reserva?\nDigite o ID da reserva que deseja encerrar ou 0 para retornar: ");
                if (int.TryParse(Console.ReadLine(), out int id) && id != 0)
                {
                    Reserva reserva = reservas.Find(r => r.Id == id);
                    if (reserva == null)
                        throw new KeyNotFoundException("ID de reserva não encontrado.");

                    reserva.Suite.Disponivel = true;
                    Console.WriteLine($"Reserva ID {id} encerrada. Custo total: R${reserva.CustoTotal:F2}");
                    reservas.Remove(reserva);
                }
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        }
    }
}