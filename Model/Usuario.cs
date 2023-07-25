using System.ComponentModel.DataAnnotations;

namespace ApiWeb.Model
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Telefone { get; set; }
        public string Endereco { get; set; }
    }
}
