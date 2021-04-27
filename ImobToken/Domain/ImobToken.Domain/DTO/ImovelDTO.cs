namespace ImobToken.Domain.DTO
{
    public class ImovelDTO
    {
        public string Nome { get; set; }
        public float Valor { get; set; }
        public int MetrosQuadrados { get; set; }
        public int FaixaRenda { get; set; }
        public int TipoImovelId { get; set; }
    }
}
