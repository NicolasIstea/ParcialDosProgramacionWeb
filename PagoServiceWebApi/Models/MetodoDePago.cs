using System.Collections.Generic;

namespace Models
{
    public class MetodoDePago : BaseEntity
    {
        public string Descripcion { get; set; }

        //Propiedades de navegacion
        public List<Pago> Pagos { get; set; }
    }
}