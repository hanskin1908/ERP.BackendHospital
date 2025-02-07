// Archivo: Pago.cs 
using ERP.Domain.Facturacion.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pago
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPago { get; set; }

    [Required]
    public int IdFactura { get; set; }  // FK a Factura

    [Required]
    public DateTime FechaPago { get; set; }

    [Required]
    public decimal MontoPagado { get; set; }

    [Required]
    [MaxLength(50)]
    public string MetodoPago { get; set; }  // Ej: Tarjeta, Efectivo, Transferencia

    // Relación: si es necesario, se puede agregar la navegación a Factura
    [ForeignKey("IdFactura")]
    public virtual Factura Factura { get; set; }
}
