using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Currency.DAL.Models
{
    public class Currency
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string CurrencyName { get; set; }
        public decimal Rate { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? RowCreatedDate { get; set; }
    }
}
