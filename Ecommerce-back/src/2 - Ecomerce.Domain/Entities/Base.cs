using System.Collections.Generic;

namespace Ecomerce.Domain.Entities
{
    public abstract class Base
    {
        public int Id { get; set; }

        //Toda entidade precisa se autovalidar
        internal List<string> _erroros;

        public IReadOnlyCollection<string> Errors => _erroros;
        public abstract bool Validate();
         
    }
}