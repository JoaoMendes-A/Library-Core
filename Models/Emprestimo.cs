namespace BiblioCore.Models
{
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
