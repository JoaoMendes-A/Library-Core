namespace BiblioCore.Models
{
    public class Usuario
    {
        // Cria um id único e aleatírio
        private static readonly Random random = new();
        
        public int Id { get; }
        public string Nome { get; set; }

        public Usuario(string nome)
        {
            Id = random.Next(1000, 10000);
            Nome = nome;
        }
    }
}