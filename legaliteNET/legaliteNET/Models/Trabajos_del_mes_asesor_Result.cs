//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace legaliteNET.Models
{
    using System;
    
    public partial class Trabajos_del_mes_asesor_Result
    {
        public Nullable<System.DateTime> fechaHoraInicio { get; set; }
        public Nullable<System.DateTime> FechaHoraFin { get; set; }
        public string actividad { get; set; }
        public string Asesor { get; set; }
        public string Requerimiento { get; set; }
        public string Observaciones { get; set; }
        public string Cliente { get; set; }
        public Nullable<decimal> costohora { get; set; }
        public Nullable<int> horas { get; set; }
        public Nullable<decimal> costo { get; set; }
    }
}