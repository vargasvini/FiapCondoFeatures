using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImobToken.Domain
{
    [Table("TIPOIMOVELTOKEN")]
    public class TipoImovel
    {
        public TipoImovel(string nome)
        {
            Nome = nome;
        }

        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("NOME")]
        public string Nome { get; set; }

        public IList<Imovel> Imoveis { get; set; }
    }
}
