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
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("cat.Usuarios")]
    public partial class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Uuid { get; set; }
        public string Nombres { get; set; }
        public bool Estatus { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public Nullable<System.DateTime> FechaBaja { get; set; }
        public Nullable<int> IdRole { get; set; }
        public Nullable<int> IdCedis { get; set; }
        public string Usuario { get; set; }
        public string Token { get; set; }
        public string Vencimiento { get; set; }
        public string Cedis { get; set; }
        public string Contrasena { get; set; }
        public string Email { get; set; }
    }
}
