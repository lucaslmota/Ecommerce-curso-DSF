using System.Collections.Generic;
using Ecomerce.Domain.Entities;

namespace Ecomerce.Services.DTO
{
    public class CompanhiaDTO
    {
        public CompanhiaDTO()
        {
        }

        public CompanhiaDTO(int id, string nomeFantasia, string razaoSocial, string cNPJ)
        {
            Id = id;
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            CNPJ = cNPJ;
        }

        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
    }
}