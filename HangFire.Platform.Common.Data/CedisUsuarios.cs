//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HangFire.Platform.Common.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class CedisUsuarios
    {
        [Key]
        public int IdCedisUsuario { get; set; }
        public string ListaCedis { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public bool Todos { get; set; }
        public int IdUsuario { get; set; }
    }
}