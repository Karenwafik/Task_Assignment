using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace Task.Models
{
    public class Invoice_Details
    {
        [Key]
        public int InvoiceDetailId { get; set; } // Primary key for Invoice Details table

        // Navigation property to InvoiceHeader entity
        [ForeignKey("InvoiceSerial")]
        public Invoice_Header Serial { get; set; }

        public string ItemName { get; set; }

        public int Quantity { get; set; }

        public int PiecePrice { get; set; }

        [NotMapped] // Not mapped to database; computed property
        public int ItemTotal => Quantity * PiecePrice;
    }
    }