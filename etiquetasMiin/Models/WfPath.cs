using System;
using System.Collections.Generic;

#nullable disable

namespace etiquetasMiin.Models
{
    public partial class WfPath
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Path { get; set; }
        public string RutaAbsoluta { get; set; }
        public string RutaVirtual { get; set; }
    }
}
