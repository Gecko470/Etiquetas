using System;
using System.Collections.Generic;

#nullable disable

namespace etiquetasMiin.Models
{
    public partial class VSageEtiquetasAlbarane
    {
        public short CodigoEmpresa { get; set; }
        public short EjercicioPedido { get; set; }
        public string SeriePedido { get; set; }
        public int NumeroPedido { get; set; }
        public short EjercicioAlbaran { get; set; }
        public string SerieAlbaran { get; set; }
        public int NumeroAlbaran { get; set; }
        public DateTime FechaAlbaran { get; set; }
        public decimal ImporteLiquido { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Municipio { get; set; }
        public string Provincia { get; set; }
        public string SiglaNacion { get; set; }
        public string Nacion { get; set; }
        public string CodigoPostal { get; set; }
        public string Telefono { get; set; }
        public string ObservacionesAlbaran { get; set; }
        public int Bultos { get; set; }
        public decimal PesoBruto { get; set; }
        public string SuPedido { get; set; }
        public string Email1 { get; set; }
    }
}
