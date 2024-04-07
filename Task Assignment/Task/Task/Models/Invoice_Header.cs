using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class Invoice_Header
    {
        [Key]
        public int Serial { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(100)]
        public string ClientName { get; set; }

        public string Notes { get; set; }

        // Navigation property for one-to-many relationship
        public ICollection<Invoice_Details> InvoiceDetails { get; set; }
    }
}

