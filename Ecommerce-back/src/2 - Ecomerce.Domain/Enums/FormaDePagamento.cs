using System.ComponentModel;

namespace Ecomerce.Domain.Enums
{
    public enum FormaDePagamento : byte
    {
        [Description("Cartão de Credito")]
        CartaoDeCredito = 1,

        [Description("Cartão de Débito")]
        CartaoDeDebito = 2,

        [Description("Boleto Bancário")]
        BoletoBancario = 3
    }
}