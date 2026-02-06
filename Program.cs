using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

class SistemaBiblioteca
{
    static void Main()
    {
        List<Biblioteca> livros = new List<Biblioteca>();
        List<Usuario> usuarios = new List<Usuario>();
        List<Emprestimo> emprestimos = new List<Emprestimo>();

        bool executando = true;

        while (executando)
        {
            ExibirMenu();

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
                    EmprestarLivro(emprestimos, livros, usuarios);
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
                    ListarEmprestimos(emprestimos);
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

// ==================== MENU ==================== //

static void ExibirMenu()
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
    }

// ==================== LISTAGENS =========================== //

// LISTA LIVROS
static void ListarLivros(List<Biblioteca> livros)
    {
        if (livros.Count > 0)
        {
            foreach (var livro in livros)
            {
                Console.WriteLine($"Titulo: {livro.Titulo} | Autor: {livro.Autor} | Quantidade: {livro.Quantidade} | Id: {livro.Id}");
            }
        } else
        {
            Console.WriteLine("Nenhum livro cadastrado.");
        }
    }

// LISTA USUARIOS
static void ListarUsuarios(List<Usuario> usuarios)
    {
        if (usuarios.Count > 0)
        {
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"Nome: {usuario.Nome} | ID: {usuario.Id}");
            }
        } else
        {
            Console.WriteLine("Nenhum usuário cadastrado.");
        }
    }

//LISTA EMPRESTIMOS
static void ListarEmprestimos(List<Emprestimo> emprestimos)
    {
        if (emprestimos.Count > 0)
        {
            foreach (var emprestimo in emprestimos)
            {
                Console.WriteLine($"O livro: {emprestimo.TituloLivro} | Emprestado para: {emprestimo.Nome} ");
            }
        } else
        {
            Console.WriteLine("Nenhum emprestimo cadastrado.");
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

// ==================== EMPRESTAR LIVRO ===================== // 

static void EmprestarLivro(List<Emprestimo> emprestimos, List<Biblioteca> livros, List<Usuario> usuarios)
    {

        Biblioteca? livro = ValidarLivro(livros, SolicitarLivro());
        Usuario? usuario = ValidarUsuario(usuarios, SolicitarUsuario());

        if(livro == null || usuario == null)
        {
            Console.WriteLine("Livro ou usuario não encontrado.");
            return;
        } 

        if (livro.Quantidade <= 0)
        {
            Console.WriteLine("Livro indisponivel.");
            return;
        }
        
        OperarEmprestimo(livros, emprestimos, usuario.Nome, usuario.Id, livro.Titulo);
        livro.Quantidade -= 1;
    }

static string SolicitarLivro()
    {
        Console.WriteLine("Digite o nome do livro:");
        return LerString();
    }

static string SolicitarUsuario()
    {
        Console.WriteLine("Digite seu nome de usuario:");
        return LerString();
    }

static Biblioteca? ValidarLivro(List<Biblioteca> livros, string nomeLivro)
    {
        return livros.Find(l => l.Titulo == nomeLivro);
    }

static Usuario? ValidarUsuario(List<Usuario> usuarios, string nomeUsuario)
    {
        return usuarios.Find(u => u.Nome == nomeUsuario);
    }

static void OperarEmprestimo(List<Biblioteca> livros, List<Emprestimo> emprestimos, string nomeUsuario, int idUsuario, string tituloLivro)
    {
        Emprestimo novoEmprestimo = new Emprestimo(nomeUsuario, idUsuario, tituloLivro);
        emprestimos.Add (novoEmprestimo);
        
    }


// ====================== LEITURA SEGURA ====================== //

// Lê e verifica se o numero é inteiro
static int LerInt() 
    {
       int valor;

       while (!int.TryParse(Console.ReadLine(), out valor)) 
        { 
            Console.Write("Entrada inválida. Digite um número inteiro: "); 
        }

        return valor;
    }

// Lê e verifica se a string não está vazia
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
    public string Titulo { get; set; }
    public string? Autor { get; set; }
    public int Quantidade { get; set; }

// BIBLIOTECA
    public Biblioteca(int id, string titulo, string autor, int quantidade)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
        Quantidade = quantidade;
    }

    public bool EmprestarLivro(string livro)
        {
            Quantidade -= 1;
            return true;
        }

}

// USUARIO
public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Usuario(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }

// EMPRESTIMO
public class Emprestimo
    {
        public string Nome { get; set; }
        public int IdUsuario { get; set; }
        public string TituloLivro { get; set; }

        public Emprestimo(string nome, int idusUario, string tituloLivro)
        {
            Nome = nome;
            IdUsuario = idusUario;
            TituloLivro = tituloLivro;
        }
    }
}

