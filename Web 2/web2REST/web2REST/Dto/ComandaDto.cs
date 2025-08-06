using System.ComponentModel.DataAnnotations.Schema;
using web2REST.Model;
using web2REST.Model.Base;

namespace web2REST.Dto
{
    public class ComandaDto
    {
        public int IdUsuario { get; set; }

        public string NomeUsuario { get; set; }

        public string TelefoneUsuario { get; set; }
    }
}
