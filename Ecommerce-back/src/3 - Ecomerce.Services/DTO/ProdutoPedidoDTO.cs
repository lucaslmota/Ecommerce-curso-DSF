namespace Ecomerce.Services.DTO
{
    public class ProdutoPedidoDTO
    {
        public ProdutoPedidoDTO()
        {
        }

        public ProdutoPedidoDTO(int id,int quantidade, int idCompra)
        {
            Id = id;
            Quantidade = quantidade;
            IdCompra = idCompra;
        }

        public int Id {get; set;}
        public int Quantidade { get; set; }
        public int IdCompra { get; set; }   
    }
}