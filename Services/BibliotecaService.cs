using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using BiblioCore.Models;

namespace BiblioCore.Services
{
    public static class BiblioCoreService
    {
        // ==================== MENU ====================

        /// <summary>
        /// Exibe o menu principal do sistema.
        /// Responsável apenas pela interface de navegação.
        /// </summary>
        
        public static void ExibirMenu()
        {   
            // Pequeno delay para melhorar experiência visual no console
            Thread.Sleep(1000);

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

        /// <summary>
        /// Lista todos os livros cadastrados.
        /// </summary>
        
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

        /// <summary>
        /// Lista todos os usuários cadastrados.
        /// </summary>
        
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

        /// <summary>
        /// Lista todos os empréstimos ativos.
        /// </summary>

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

        /// <summary>
        /// Realiza o cadastro de um novo livro.
        /// </summary>
        
        public static void CadastrarLivro(List<Biblioteca> livros)
        {
            Console.WriteLine("\n=== Cadastro ===");

            Console.WriteLine("Título:");
            string titulo = LerString();

            Console.WriteLine("Autor:");
            string autor = LerString();

            Console.WriteLine("Quantidade:");
            int quantidade = LerInt();

            Biblioteca novoLivro = new Biblioteca(titulo, autor, quantidade);
            livros.Add(novoLivro);
        }

        /// <summary>
        /// Realiza o cadastro de um novo usuário.
        /// </summary>
        
        public static void CadastrarUsuario(List<Usuario> usuarios)
        {
            Console.WriteLine("\n=== Cadastro de Usuário ===");

            Console.WriteLine("Nome:");
            string nome = LerString();

            Usuario novoUsuario = new Usuario(nome);
            usuarios.Add(novoUsuario);
        }

        // ==================== EMPRÉSTIMO ====================

        /// <summary>
        /// Fluxo de empréstimo de livro.
        /// Valida usuário, livro e disponibilidade.
        /// </summary>
        
        public static void EmprestarLivro(
            List<Emprestimo> emprestimos,
            List<Biblioteca> livros,
            List<Usuario> usuarios)
        {
            Biblioteca? livro = ValidarLivro(livros, SolicitarLivro());
            Usuario? usuario = ValidarUsuario(usuarios, SolicitarUsuario());

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            if (usuario == null)
            {
                Console.WriteLine("Usuário não encontrado.");
                return;
            }

            if (livro.Quantidade <= 0)
            {
                Console.WriteLine("Livro indisponível.");
                return;
            }

            OperarEmprestimo(emprestimos,
                usuario.Nome,
                usuario.Id,
                livro.Titulo,
                livro.Id);

            // Atualiza estoque
            livro.Quantidade -= 1;
        }


        /// <summary>
        /// Executa a operação de empréstimo.
        /// Cria registro na lista de empréstimos.
        /// </summary>
        
        private static void OperarEmprestimo(
            List<Emprestimo> emprestimos,
            string nomeUsuario,
            int idUsuario,
            string tituloLivro,
            int idLivro)
        {
            Emprestimo novoEmprestimo =
                new Emprestimo(nomeUsuario, idUsuario, tituloLivro, idLivro);

            emprestimos.Add(novoEmprestimo);

            Console.WriteLine(
                $"O livro {tituloLivro} foi emprestado para {nomeUsuario}"
            );
        }

        // ==================== DEVOLUÇÃO ======================

        /// <summary>
        /// Fluxo de devolução de livro.
        /// Valida usuário e empréstimo ativo.
        /// </summary>
        
        public static void DevolverLivro(
            List<Emprestimo> emprestimos,
            List<Usuario> usuarios,
            List<Biblioteca> livros)
        {
            Usuario? usuario = ValidarUsuario(usuarios, SolicitarUsuario());

            if (usuario == null)
            {
                Console.WriteLine("Usuário não encontrado.");
                return;
            }

            Emprestimo? emprestado = ValidarEmprestimo(emprestimos, usuario.Id);

            if (emprestado == null)
            {
                Console.WriteLine("Emprestimo não encontrado.");
                return;
            }

            OperarDevolucao(emprestado, emprestimos, livros);
        }

        /// <summary>
        /// Executa a devolução:
        /// - Remove empréstimo ativo
        /// - Atualiza estoque do livro
        /// </summary>

        static void OperarDevolucao(
            Emprestimo emprestado,
            List<Emprestimo> emprestimos,
            List<Biblioteca> livros)
        {
            Biblioteca? livro = ValidarLivro(livros, emprestado.TituloLivro);

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            // Devolve ao estoque
            livro.Quantidade += 1;

            // Remove registro de empréstimo
            emprestimos.Remove(emprestado);

            Console.WriteLine("Livro devolvido com sucesso!");
        }
    
        
        // ==================== VALIDAÇÃO =====================

        /// <summary>
        /// Busca livro pelo título.
        /// </summary>
        
        private static Biblioteca? ValidarLivro(List<Biblioteca> livros, string nomeLivro)
        {
            return livros.Find(l => l.Titulo == nomeLivro);
        }


        /// <summary>
        /// Busca usuário pelo nome.
        /// </summary>
        
        private static Usuario? ValidarUsuario(List<Usuario> usuarios, string nomeUsuario)
        {
            return usuarios.Find(u => u.Nome == nomeUsuario);
        }

        /// <summary>
        /// Busca empréstimo ativo pelo Id do usuário.
        /// </summary>
        
        private static Emprestimo? ValidarEmprestimo(List<Emprestimo> emprestimos, int idEmprestimo)
        {
            return emprestimos.Find(e => e.IdUsuario == idEmprestimo);
        }

        // ==================== AUXILIARES ====================

        /// <summary>
        /// Solicita nome do livro ao usuário.
        /// </summary>
        
        private static string SolicitarLivro()
        {
            Console.WriteLine("Digite o nome do livro:");
            return LerString();
        }

        /// <summary>
        /// Solicita nome do usuário.
        /// </summary>
        
        private static string SolicitarUsuario()
        {
            Console.WriteLine("Digite o nome do usuário:");
            return LerString();
        }

        // ==================== LEITURA ====================

        /// <summary>
        /// Lê número inteiro com validação.
        /// </summary>
        
        public static int LerInt()
        {
            int valor;

            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write("Entrada inválida. Digite um número inteiro: ");
            }

            return valor;
        }

        /// <summary>
        /// Lê texto não vazio.
        /// </summary>
        
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
    }
}
