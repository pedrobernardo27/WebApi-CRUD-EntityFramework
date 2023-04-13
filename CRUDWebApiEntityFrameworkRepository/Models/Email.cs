using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDWebApiEntityFrameworkRepository.Models
{
    [Table("Email")]
    public class Email
    {
        [Key]
        public int Id { get; set; }
        public string Pessoal{ get; set; }
        public string Empresarial { get; set; }
        public int Id_Pessoa { get; set; }
        public virtual Pessoa? Pessoa { get; set; }
    }
}
