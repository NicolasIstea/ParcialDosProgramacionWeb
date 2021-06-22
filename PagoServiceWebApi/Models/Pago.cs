using System;

namespace Models
{
    public class Pago : BaseEntity
    {
        public string Descripcion { get; set; }
        public decimal Deuda { get; set; }
        public bool Pagado { get; set; }
        public int MetodoDePagoId { get; set; }

        //Propiedad de Navegacion
        public virtual MetodoDePago MetodoDePago { get; set; }

    }
}
