//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NomiPro.ModelDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class TIPO_VINCULACION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPO_VINCULACION()
        {
            this.EMPLEADOS = new HashSet<EMPLEADOS>();
        }
    
        public int ID_Vinculacion { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLEADOS> EMPLEADOS { get; set; }
    }
}
