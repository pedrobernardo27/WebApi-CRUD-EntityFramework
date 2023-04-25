using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CRUDWebApiEntityFrameworkRepository.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string? Cep { get; set; }
        public int Id_Pessoa { get; set; }
        public virtual Pessoa? Pessoa { get; set; }

    }
}
