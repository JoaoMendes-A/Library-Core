using System;
using System.Collections.Generic;
using BiblioCore.Models;
using BiblioCore.Services;

namespace BiblioCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // Listas principais do sistema (simulam um banco de dados em memória)
            List<Biblioteca> livros = new List<Biblioteca>();
            List<Usuario> usuarios = new List<Usuario>();
            List<Emprestimo> emprestimos = new List<Emprestimo>();

            // Controla a execução do sistema (loop do menu)
            bool executando = true;

            // Loop principal da aplicação
            while (executando)
            {
                // Exibe as opções disponíveis no sistema
                BiblioCoreService.ExibirMenu();

                // Lê a opção digitada pelo usuário
                int opcao = BiblioCoreService.LerInt();

                // Fluxo de navegação do menu
                switch (opcao)
                {
                    case 1:
                        // Cadastra um novo livro na lista
                        BiblioCoreService.CadastrarLivro(livros);
                        break;

                    case 2:
                        // Cadastra um novo usuário
                        BiblioCoreService.CadastrarUsuario(usuarios);
                        break;

                    case 3:
                        // Realiza o empréstimo de um livro, atualiza lista de empréstimos e estoque
                        BiblioCoreService.EmprestarLivro(
                            emprestimos, livros, usuarios);
                        break;

                    case 4:
                        // Realiza a devolução de um livro, remove empréstimo e devolve ao estoque
                        BiblioCoreService.DevolverLivro(
                            emprestimos, usuarios, livros);
                        break;

                    case 5:
                        // Lista todos os livros cadastrados
                        BiblioCoreService.ListarLivros(livros);
                        break;

                    case 6:
                        // Lista todos os usuários cadastrados
                        BiblioCoreService.ListarUsuarios(usuarios);
                        break;

                    case 7:
                        // Lista todos os empréstimos ativos
                        BiblioCoreService.ListarEmprestimos(emprestimos);
                        break;

                    case 8:
                        // Encerra o sistema
                        Console.WriteLine("Sistema encerrado.");
                        executando = false;
                        break;

                    default:
                        // Tratamento para opções inválidas
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}