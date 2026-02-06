namespace BiblioCore.Models
{
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
}