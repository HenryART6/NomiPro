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
    
    public partial class CONTROL_PAGO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTROL_PAGO()
        {
            this.NOMINA = new HashSet<NOMINA>();
        }
    
        public int ID_Control_Pago { get; set; }
        public Nullable<int> ID_EmpleCP { get; set; }
        public Nullable<int> Valor_Horas_Extra { get; set; }
        public Nullable<int> Valor_Parafiscal { get; set; }
        public string Mes { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOMINA> NOMINA { get; set; }
        public virtual EMPLEADOS EMPLEADOS { get; set; }
    }
}
