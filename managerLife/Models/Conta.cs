using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Contas
{
    public class Conta 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set;}

        [MaxLength(255)]
        public required string Cobrador { get; set;}
        
        public virtual required Categoria Categoria { get; set;}

        public required double Total { get; set;}

        public required DateTime DataCompra { get; set;}

        [MaxLength(255)]
        public string? Observacao { get; set;}
    }
}