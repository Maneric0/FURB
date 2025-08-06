using web2REST.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace web2REST.Model
{
    [Table("comanda")]
    public class Comanda : BaseEntity
    {
        [Column("idUsuario")]
        public int IdUsuario { get; set; }

        [Column("nomeUsuario")]
        public string NomeUsuario { get; set; }

        [Column("telefoneUsuario")]
        public string TelefoneUsuario { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}
