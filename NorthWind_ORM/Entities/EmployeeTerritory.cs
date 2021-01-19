namespace NorthWind_ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Northwind.EmployeeTerritories")]
    public partial class EmployeeTerritory
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string TerritoryID { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
