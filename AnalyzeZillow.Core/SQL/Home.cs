namespace AnalyzeZillow.Core.SQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Home
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int zId { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(10)]
        public string State { get; set; }

        public int ZipCode { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public int FIPSCounty { get; set; }

        [Required]
        [StringLength(50)]
        public string HomeType { get; set; }

        public int TaxAssesmentYear { get; set; }

        public decimal TaxAssessment { get; set; }

        public int YearBuild { get; set; }

        public int LotSize { get; set; }

        public int HomeSize { get; set; }

        public decimal NumBathrooms { get; set; }

        public int NumBedrooms { get; set; }

        public double TotalRooms { get; set; }

        public double ZillowEstimate { get; set; }

        public double ZillowLowEstimate { get; set; }

        public double ZillowHighEstimate { get; set; }

        public double LastSoldPrice { get; set; }

        public DateTime LastSoldDate { get; set; }
    }
}
