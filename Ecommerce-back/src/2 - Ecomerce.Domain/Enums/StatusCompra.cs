using System.ComponentModel;

namespace Ecomerce.Domain.Enums
{
    public enum StatusCompra : byte
    {
        [Description("Pago")]
        Pago =1,
        [Description("Aberto")]
        Aberto = 2
    }
}