using System.ComponentModel.DataAnnotations;

namespace Models.Contas
{
    public class Categoria 
    {
        public int Id { get; set;}

        [MaxLength(255)]        
        public string? Nome { get; set; }
    }
}