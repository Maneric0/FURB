using web2REST.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace web2REST.Model
{
    [Table("produto")]
    public class Produto : BaseEntity
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("preco")]
        public double Preco { get; set; }

        [Column("comandaId")]
        public int ComandaId { get; set; }
    }
}
