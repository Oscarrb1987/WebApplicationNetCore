using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationNetCore.Models
{
    [Table("personasEjercicio")]
    public partial class PersonasEjercicio
    {
        [Key]
        [StringLength(50)]
        public string Nif { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Apellidos { get; set; }
        [StringLength(50)]
        public string Direccion { get; set; }
        [StringLength(50)]
        public string Ciudad { get; set; }
        [Column("Estado_Civil")]
        [StringLength(50)]
        public string EstadoCivil { get; set; }
        [StringLength(50)]
        public string Sexo { get; set; }
        [Column("Codigo_Postal")]
        [StringLength(50)]
        public string CodigoPostal { get; set; }
        [StringLength(50)]
        public string Provincia { get; set; }
    }
}
