namespace Ecomerce.Services.DTO
{
    public class ProdutoDTO
    {
        public ProdutoDTO()
        {
        }

        public ProdutoDTO(int idCompanhia ,int id, string nome, string descricao, float valor, string observacao)
        {
            IdCompanhia = idCompanhia;
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Observacao = observacao;
        }

        public int IdCompanhia { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Valor { get; set; }
        public string Observacao { get; set; }
    }
}