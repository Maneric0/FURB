using System.ComponentModel.DataAnnotations.Schema;

namespace web2REST.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
