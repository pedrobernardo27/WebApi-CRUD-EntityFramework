using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDWebApiEntityFrameworkRepository.Models
{
    [Table("Endereco")]
    public class EnderecoRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string? Cep { get; set; }
        [JsonIgnore]
        public int Id_Pessoa { get; set; }
    }
}
