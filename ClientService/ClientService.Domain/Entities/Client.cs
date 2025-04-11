using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientService.Domain.Entities
{
    [Table("Cliente")]
    public class Client
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("RazaoSocial")]
        public string Name { get; set; }
        [Column("CNPJ")]
        public string Cnpj { get; set; }
        [Column("Rede")]
        public string Path { get; set; }
        [Column("Email")]
        public string? Email { get; set; }
        [Column("Telefone")]
        public string? Phone { get; set; }
        [Column("Ativo")]
        public string Active { get; set; }
    }
}
