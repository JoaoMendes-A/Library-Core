using System;
using System.Collections.Generic;

class SistemaBiblioteca
{
    static void Main()
    {
        List<Biblioteca> livros = new List<Biblioteca>();

        bool executando = true;

        while (executando)
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1 - Cadastrar livro");
            Console.WriteLine("2 - Cadastrar usuário");
            Console.WriteLine("3 - Emprestar livro");
            Console.WriteLine("4 - Devolver livro");
            Console.WriteLine("5 - Listar livros");
            Console.WriteLine("6 - Listar usuários");
            Console.WriteLine("7 - Listar empréstimos ativos");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("Opção: ");

            int opcao = LerInt();

            switch (opcao)
            {
                case 1:
                    CadastrarLivro(livros);
                    break;

                case 2:

                    break;

                case 3:

                    break;

                case 4:

                    break;
                
                case 5:

                    break;
                
                case 6:

                    break;
                
                case 7:

                    break;

                case 8:
                    Console.WriteLine("Sistema encerrado.");
                    executando = false;
                    break;
                    
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

static void CadastrarLivro(List<Biblioteca> livros)
{
    Console.WriteLine("\n=== Cadastro ===");

    Console.WriteLine("Título Do Livro:");
    string titulo = LerString();

    Console.WriteLine("Autor Do Livro:");
    string autor = LerString();

    Console.WriteLine("Quantidade No Estoque:");
    int quantidade = LerInt();

    int id = 1;

    Biblioteca novoLivro = new Biblioteca(id, titulo, autor, quantidade);
    livros.Add(novoLivro);
    
}

// ====================== LEITURA SEGURA ====================== //
static int LerInt()
    {
       int valor;

       while (!int.TryParse(Console.ReadLine(), out valor)) 
        { 
            Console.Write("Entrada inválida. Digite um número inteiro: "); 
        }

        return valor;
    }

static string LerString()
    {    
        string? texto;

        do
        {
            texto = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(texto))
            {
                Console.WriteLine("Entrada inválida. Digite um texto: ");
            }
        } while (string.IsNullOrWhiteSpace(texto));
        
        return texto;
        
    }

// =================== CLASE LIVROS ==================== //
class Biblioteca
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public string? Autor { get; set; }
    public int Quantidade { get; set; }

    public Biblioteca(int id, string titulo, string autor, int quantidade)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
        Quantidade = quantidade;
    }
}


}