using System.Text.Json.Serialization;

namespace CRUDWebApiEntityFrameworkRepository.Models
{   
    public class EmailRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Pessoal { get; set; }
        public string? Empresarial { get; set; }
        [JsonIgnore]
        public int Id_Pessoa { get; set; }
        [JsonIgnore]
        public virtual Pessoa? Pessoa { get; set; }
    }
}
