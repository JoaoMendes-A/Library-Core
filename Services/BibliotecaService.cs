using System;
using System.Collections.Generic;
using BiblioCore.Models;

namespace BiblioCore.Services
{
    public static class BiblioCoreService
    {
        // ==================== MENU ====================

        public static void ExibirMenu()
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

        // ==================== LISTAGENS ====================

        public static void ListarLivros(List<Biblioteca> livros)
        {
            if (livros.Count > 0)
            {
                foreach (var livro in livros)
                {
                    Console.WriteLine(
                        $"Titulo: {livro.Titulo} | Autor: {livro.Autor} | Quantidade: {livro.Quantidade} | Id: {livro.Id}"
                    );
                }
            }
            else
            {
                Console.WriteLine("Nenhum livro cadastrado.");
            }
        }

        public static void ListarUsuarios(List<Usuario> usuarios)
        {
            if (usuarios.Count > 0)
            {
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine($"Nome: {usuario.Nome} | ID: {usuario.Id}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
            }
        }

        public static void ListarEmprestimos(List<Emprestimo> emprestimos)
        {
            if (emprestimos.Count > 0)
            {
                foreach (var emprestimo in emprestimos)
                {
                    Console.WriteLine(
                        $"Livro: {emprestimo.TituloLivro} | Usuário: {emprestimo.Nome}"
                    );
                }
            }
            else
            {
                Console.WriteLine("Nenhum empréstimo cadastrado.");
            }
        }

        // ==================== CADASTROS ====================

        public static void CadastrarLivro(List<Biblioteca> livros)
        {
            Console.WriteLine("\n=== Cadastro ===");

            Console.WriteLine("Título:");
            string titulo = LerString();

            Console.WriteLine("Autor:");
            string autor = LerString();

            Console.WriteLine("Quantidade:");
            int quantidade = LerInt();

            int id = GerarIdAleatorio();

            Biblioteca novoLivro = new Biblioteca(id, titulo, autor, quantidade);
            livros.Add(novoLivro);
        }

        public static void CadastrarUsuario(List<Usuario> usuarios)
        {
            Console.WriteLine("\n=== Cadastro de Usuário ===");

            Console.WriteLine("Nome:");
            string nome = LerString();

            int id = GerarIdAleatorio();

            Usuario novoUsuario = new Usuario(id, nome);
            usuarios.Add(novoUsuario);
        }

        // ==================== EMPRÉSTIMO ====================

        public static void EmprestarLivro(
            List<Emprestimo> emprestimos,
            List<Biblioteca> livros,
            List<Usuario> usuarios)
        {
            Biblioteca? livro = ValidarLivro(livros, SolicitarLivro());
            Usuario? usuario = ValidarUsuario(usuarios, SolicitarUsuario());

            if (livro == null || usuario == null)
            {
                Console.WriteLine("Livro ou usuário não encontrado.");
                return;
            }

            if (livro.Quantidade <= 0)
            {
                Console.WriteLine("Livro indisponível.");
                return;
            }

            OperarEmprestimo(emprestimos, usuario.Nome, usuario.Id, livro.Titulo);
            livro.Quantidade -= 1;
        }

        // ==================== AUXILIARES ====================

        private static string SolicitarLivro()
        {
            Console.WriteLine("Digite o nome do livro:");
            return LerString();
        }

        private static string SolicitarUsuario()
        {
            Console.WriteLine("Digite o nome do usuário:");
            return LerString();
        }

        private static Biblioteca? ValidarLivro(List<Biblioteca> livros, string nomeLivro)
        {
            return livros.Find(l => l.Titulo == nomeLivro);
        }

        private static Usuario? ValidarUsuario(List<Usuario> usuarios, string nomeUsuario)
        {
            return usuarios.Find(u => u.Nome == nomeUsuario);
        }

        private static void OperarEmprestimo(
            List<Emprestimo> emprestimos,
            string nomeUsuario,
            int idUsuario,
            string tituloLivro)
        {
            Emprestimo novoEmprestimo =
                new Emprestimo(nomeUsuario, idUsuario, tituloLivro);

            emprestimos.Add(novoEmprestimo);

            Console.WriteLine(
                $"O livro {tituloLivro} foi emprestado para {nomeUsuario}"
            );
        }

        // ==================== LEITURA ====================

        public static int LerInt()
        {
            int valor;

            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write("Entrada inválida. Digite um número inteiro: ");
            }

            return valor;
        }

        public static string LerString()
        {
            string? texto;

            do
            {
                texto = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(texto))
                {
                    Console.Write("Entrada inválida. Digite um texto: ");
                }

            } while (string.IsNullOrWhiteSpace(texto));

            return texto;
        }

        private static int GerarIdAleatorio()
        {
            Random rdn = new Random();
            return rdn.Next(10000, 100000);
        }
    }
}
