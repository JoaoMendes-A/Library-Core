using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

class SistemaBiblioteca
{
    static void Main()
    {
        List<Biblioteca> livros = new List<Biblioteca>();
        List<Usuario> usuarios = new List<Usuario>();

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
            Console.WriteLine("8 - Sair");
            Console.WriteLine("Opção: ");

            int opcao = LerInt();

            switch (opcao)
            {
                case 1:
                    CadastrarLivro(livros);
                    break;

                case 2:
                    CadastrarUsuario(usuarios);
                    break;

                case 3:

                    break;

                case 4:

                    break;
                
                case 5:
                    ListarLivros(livros);
                    break;
                
                case 6:
                    ListarUsuarios(usuarios);
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
// ==================== CADASTRAR LIVRO ===================== //
static void CadastrarLivro(List<Biblioteca> livros)
{
    Console.WriteLine("\n=== Cadastro ===");

    Console.WriteLine("Título Do Livro:");
    string titulo = LerString();

    Console.WriteLine("Autor Do Livro:");
    string autor = LerString();

    Console.WriteLine("Quantidade No Estoque:");
    int quantidade = LerInt();

    int id = GerarIdAleatorio();

    Biblioteca novoLivro = new Biblioteca(id, titulo, autor, quantidade);
    livros.Add(novoLivro);

    
}
static void ListarLivros(List<Biblioteca> livros)
    {
        foreach (var livro in livros)
        {
            Console.WriteLine($"Titulo: {livro.Titulo} | Autor: {livro.Autor} | Quantidade: {livro.Quantidade}");
        }
    }



// ====================== CADASTRAR USUÁRIO ==================== //
static void CadastrarUsuario(List<Usuario> usuarios)
    {
        Console.WriteLine("\n=== Cadastro De Usuário ===");

        Console.WriteLine("Nome:");
        string nome = LerString();

        int id = GerarIdAleatorio();

        Usuario novoUsuario = new Usuario(id, nome);
        usuarios.Add(novoUsuario);

    }

static void ListarUsuarios(List<Usuario> usuarios)
    {
        foreach (var usuario in usuarios)
        {
            Console.WriteLine($"Nome: {usuario.Nome} | ID: {usuario.Id}");
        }
    }

// ====================== LEITURA SEGURA ====================== //
static int LerInt() // Lê e verifica se o numero é inteiro
    {
       int valor;

       while (!int.TryParse(Console.ReadLine(), out valor)) 
        { 
            Console.Write("Entrada inválida. Digite um número inteiro: "); 
        }

        return valor;
    }

static string LerString() // Lê e verifica se a string não está vazia
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
// ===================== GERA ID ====================== //

static int GerarIdAleatorio() 
    {
        Random rdn = new Random();
        int id = rdn.Next(10000, 100000);

        return id;
    }

// =================== CLASSES ==================== //
public class Biblioteca
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

public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public Usuario(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}