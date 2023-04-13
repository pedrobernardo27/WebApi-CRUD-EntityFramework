using System.Text.Json.Serialization;

namespace CRUDWebApiEntityFrameworkRepository.Models
{
    public class PessoaResponse
    {        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        [JsonPropertyName("Email")]
        public virtual ICollection<EmailResponse>? EmailResponse { get; set; }
    }
}
