
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImobToken.Domain
{

    [Table("IMOVELTOKEN")]
    public class Imovel
    {
        public Imovel(string nome, float valor, int metrosQuadrados, int faixaRenda, int tipoImovelId)
        {
            Nome = nome;
            Valor = valor;
            MetrosQuadrados = metrosQuadrados;
            FaixaRenda = faixaRenda;
            TipoImovelId = tipoImovelId;
        }

        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("NOME")]
        public string Nome { get; set; }
        [Column("VALOR")]
        public float Valor { get; set; }
        [Column("METROSQUADRADOS")]
        public int MetrosQuadrados { get; set; }
        [Column("FAIXARENDA")]
        public int FaixaRenda { get; set; }
        [Column("TIPOIMOVELID")]
        public int TipoImovelId { get; set; }

        public TipoImovel TipoImovel { get; set; }

    }
    
}
