using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImobToken.Domain
{
    [Table("TIPOIMOVEL")]
    public class TipoImovel
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("NOME")]
        public string Nome { get; set; }
    }
}
