# WEX End-to-End Engineering | Sistema de Hospedagem em .NET com C#

Repositório educacional criado para consolidar o aprendizado da plataforma .NET com C#, baseado no curso _WEX - End to End Engineering_ da [DIO](https://web.dio.me). Este projeto combina prática e teoria, demonstrando o uso de coleções `List` e `Dictionary` em um sistema de gerenciamento de hotel.

![GitHub repo size](https://img.shields.io/github/repo-size/fzanneti/dio-and-wex-hotel-challenge)
![GitHub forks](https://img.shields.io/github/forks/fzanneti/dio-and-wex-hotel-challenge?style=social)
![GitHub Repo stars](https://img.shields.io/github/stars/fzanneti/dio-and-wex-hotel-challenge?style=social)
![Linguagem](https://img.shields.io/badge/Linguagem-CSharp-blue)
![Bootcamp](https://img.shields.io/badge/WEX-End--to--End%20Engineering-blueviolet?logo=vercel&logoColor=white)
![Plataforma](https://img.shields.io/badge/Powered%20by-DIO.io-red?logo=data:image/svg+xml;base64,PHN2ZyBmaWxsPSIjZmZmIiB2aWV3Qm94PSIwIDAgMzIgMzIiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+PHBhdGggZD0iTTYuNzEgMy4yNWMtMi44OCAxLjQxLTUuMDcgNC4yMy01LjA3IDcuNzYgMCAzLjU4IDIuMjggNi43IDUuMzMgOC4xNSAxLjgzLS42MiAyLjQtMi4yNiAyLjQtMy44MSAwLS4yMy0uMDItLjQ1LS4wNS0uNjZBLjQ0LjQ0IDAgMDExMC4xIDExYy4yNC0uNzUuMTEtMS41My0uMy0yLjIyQzguOTIgNy45NiA3LjMzIDcuNSA1Ljc0IDcuNjZhNS41NSA1LjU1IDAgM)
![Autor](https://img.shields.io/badge/Autor-fzanneti-blue?style=flat-square&logo=github)

---

## Conteúdo

Este repositório apresenta o projeto **Hospedagem / Hotelaria**, um aplicativo console em C# que gerencia hospedagens, suítes e reservas, com opção de usar `List` ou `Dictionary`. O conteúdo é organizado em módulos de aprendizado, com exemplos práticos e explicações.

---

### Fundamentos do .NET e C#

- **Plataforma .NET**: Introdução ao .NET 8.0
- **C#**: Tipagem forte, sintaxe moderna, e integração com .NET.
- **Estrutura do Projeto**: Uso de namespaces, classes, e interfaces.
- **Exemplo**:

```csharp

CultureInfo.CurrentCulture = new CultureInfo("pt-BR"); // Define formatação brasileira
Console.WriteLine(500.50m.ToString("C")); // Saída: R$ 500,50

```

---

### Links:    

🔗[Documentação .NET](https://learn.microsoft.com/dotnet)     
🔗[História do C#](https://learn.microsoft.com/csharp/tour-of-csharp)

---

## Sintaxe e Lógica de Programação

### Variáveis e Tipos:

```csharp

int id = 1;
string nome = "João";
decimal preco = 450.00m;

```

---

### Condicionais*:

```csharp
  
if (dias >= 10)
  custo *= 0.9m; // Aplica desconto

```

---

### Laços:

```csharp
  
foreach (var h in hospedes)
  Console.WriteLine(h.ToString());

```

---

### Métodos:

```csharp

private decimal CalcularCusto()
{
  decimal custo = Dias * Suite.PrecDiaria;
  return Dias >= 10 ? custo * 0.9m : custo;
}
  
```

---

- **Aplicação**: O menu interativo usa `switch` para navegar pelas opções, e validações garantem entradas seguras.

---

## Programação Orientada a Objetos

- **Classes**:

  - `Hospede`: Armazena ID, Nome, Sobrenome.
  - `Suite`: Inclui ID, Nome, Preço Diária, Capacidade, Disponibilidade.
  - `Reserva`: Gerencia ID, Hóspede, Suíte, Dias, Custo Total.
 
---

- **Exemplo**:

```csharp

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
}

```

---

- **Encapsulamento**: Propriedades com validação no construtor.

---

## Manipulando Valores com C#

### Formatação Monetária:

```csharp

  Console.WriteLine(s.PrecioDiaria.ToString("C2", new CultureInfo("pt-BR"))); // Saída: R$450,00

```

---

### Validação de Entradas:

```csharp
 
if (!int.TryParse(Console.ReadLine(), out int id))
  throw new ArgumentException("ID inválido.");

```

---

### Cultura:

```csharp

CultureInfo cultura = new CultureInfo("pt-BR");
Console.WriteLine(custo.ToString("C2", cultura)); // Saída: R$2250,00

```

---

- **Aplicação**: Preços formatados em reais, validação de números inteiros e decimais.

---

## Tratamento de Exceções

- **Bloco `try-catch`**:

```csharp

try
  {
    if (!int.TryParse(Console.ReadLine(), out int id))
      throw new ArgumentException("ID inválido.");
  }
  catch (ArgumentException ex)
  {
    Console.WriteLine($"Erro: {ex.Message}");
  }

```

---

### Exceções Específicas:

  - `KeyNotFoundException`: Para IDs inválidos.
  - `ArgumentException`: Para entradas inválidas.
  - `InvalidOperationException`: Para ações proibidas.

---

### Exportação CSV:

```csharp

try
{
  using (var writer = new StreamWriter("hospedes.csv"))
  {
    writer.WriteLine("ID,Nome,Sobrenome");
    foreach (var h in hospedes)
    writer.WriteLine($"{h.Id},{h.Nome},{h.Sobrenome}");
  }
}
catch (IOException)
{
  Console.WriteLine("Erro ao acessar o arquivo hospedes.csv.");
}

```

---

## Coleções em C#

### List:

- Usada em `hotel_list`.
- Busca linear (O(n)).

---

### Exemplo:

```csharp

List<Hospede> hospedes = new List<Hospede>();
hospedes.Add(new Hospede(1, "João", "Silva"));
var hospede = hospedes.Find(h => h.Id == 1);

```

---

### Dictionary:

- Usada em `hotel_dictionary`.
- Busca por chave (O(1)).

---

### Exemplo:

```csharp

Dictionary<int, Hospede> hospedes = new Dictionary<int, Hospede>();
hospedes.Add(1, new Hospede(1, "Maria", "Oliveira"));
var hospede = hospedes[1];

```

---

### Comparação:

  | Coleção   | Busca | Inserção | Remoção | Caso de Uso              |
  |-------------|---------|------------|-----------|-----------------------|
  | List       | O(n)   | O(1)     | O(n)     | Coleções pequenas     |
  | Dictionary | O(1)     | O(1)      | O(1)      | Acesso rápido por ID  |

---

- **Aplicação**: O usuário escolhe entre `List` e `Dictionary` no início, permitindo comparar desempenho.

---

## Objetivo

- Fornecer um projeto prático que consolide fundamentos de C# e .NET.
- Demonstrar habilidades em POO, coleções, e tratamento de erros.
- Servir como portfólio para transição de carreira em tecnologia.
- Preparar para desafios técnicos com clareza e confiança.

---

## Para quem é este projeto?

- 🧑‍💻 Iniciantes em .NET e C#.
- 🎓 Alunos do curso WEX - End-to-End Engineering.
- 🔁 Profissionais em transição de carreira.
- 📚 Estudantes reforçando fundamentos.
- 🧠 Autodidatas buscando prática organizada.

---

### Links Úteis

🔗[Documentação Oficial .NET](https://learn.microsoft.com/dotnet)

---

##### ✍️ Seção criada por: *Fabio Zanneti* - 🎯 Bootcamp: **WEX - End to End Engineering**
[![GitHub](https://img.shields.io/badge/GitHub-fzanneti-181717?style=flat&logo=github)](https://github.com/fzanneti)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-fzanneti-0A66C2?style=flat&logo=linkedin&logoColor=white)](https://linkedin.com/in/fzanneti)
