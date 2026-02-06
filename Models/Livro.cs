namespace BiblioCore.Models
{
    public class Biblioteca
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
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