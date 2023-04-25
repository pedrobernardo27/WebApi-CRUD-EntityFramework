using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDWebApiEntityFrameworkRepository.Models
{
    [Table("Pessoa")]
    public class PessoaRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public virtual ICollection<EmailRequest>? Email { get; set; }
    }
}
