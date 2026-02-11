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
            List<Biblioteca> livros = new List<Biblioteca>();
            List<Usuario> usuarios = new List<Usuario>();
            List<Emprestimo> emprestimos = new List<Emprestimo>();

            Biblioteca livro1 = new Biblioteca(
            1,
            "aaa",
            "Machado de Assis",
            5
            );
            livros.Add(livro1);

            Usuario usuer1 = new Usuario(
                12,
                "Joao"
            );

            usuarios.Add (usuer1);

            bool executando = true;

            while (executando)
            {
                BiblioCoreService.ExibirMenu();

                int opcao = BiblioCoreService.LerInt();

                switch (opcao)
                {
                    case 1:
                        BiblioCoreService.CadastrarLivro(livros);
                        break;

                    case 2:
                        BiblioCoreService.CadastrarUsuario(usuarios);
                        break;

                    case 3:
                        BiblioCoreService.EmprestarLivro(emprestimos, livros, usuarios);
                        break;

                    case 4:
                        BiblioCoreService.DevolverLivro(emprestimos, usuarios);
                        break;

                    case 5:
                        BiblioCoreService.ListarLivros(livros);
                        break;

                    case 6:
                        BiblioCoreService.ListarUsuarios(usuarios);
                        break;

                    case 7:
                        BiblioCoreService.ListarEmprestimos(emprestimos);
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
    }
}
