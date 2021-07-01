namespace Ecomerce.Services.DTO
{
    public class UsuarioDTO
    {
        public UsuarioDTO()
        {
        }

        public UsuarioDTO(int id, string nome, string email, string senha, string cpf)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Cpf = cpf;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        
        
    }
}