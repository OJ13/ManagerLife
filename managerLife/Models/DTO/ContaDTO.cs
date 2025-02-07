using System;
using System.Collections.Generic;

namespace Models.ContasDTO
{
    public record CategoriaDTO(int Id, string Nome);

    // public record Itens(int Id, string Descricao, int ValorUnitario, int Qtd, int ValorTotal, Categoria Categoria);

    // public record Debito(Guid Id, string Cobrador, Categoria Categoria, int Total, DateTime DataCompra, ICollection<Itens> itens);
}


// {
//   cobrador: sring,
//   categoria: { id, name}
//   total: numerico,
//   data_compra: date,
//   itens?: [
//    {
//     descricao: string,
//     valor_unitario: numerico,
//     qtd: inteiro,
//     valor_total?: numerico,
//     categoria?: {
//       id: string,
//       name: string
//      }
//    }
//   ]
// }