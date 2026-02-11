namespace BiblioCore.Models
{
    public class Biblioteca
    {
        // Cria um id único e aleatírio
        private static readonly Random random = new();
        
        public int Id { get; }
        public string Titulo { get; set; }
        public string? Autor { get; set; }
        public int Quantidade { get; set; }

        public Biblioteca(string titulo, string autor, int quantidade)
        {
            Id = random.Next(10000, 100000);
            Titulo = titulo;
            Autor = autor;
            Quantidade = quantidade;
        }
    }
}