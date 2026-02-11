namespace BiblioCore.Models
{
    public class Emprestimo
    {
        public string Nome { get; set; }
        public int IdUsuario { get; set; }
        public string TituloLivro { get; set; }
        public int IdLivro { get; set; }

        public Emprestimo(string nome, int idusUario, string tituloLivro, int idLivro)
        {
            Nome = nome;
            IdUsuario = idusUario;
            TituloLivro = tituloLivro;
            IdLivro = idLivro;
        }
    }
}
