namespace ERP.Domain.Facturacion.Entidades
{
    public enum EstadoFactura
    {
        Pendiente,  // La factura aún no ha sido pagada.
        Pagada,     // La factura ha sido pagada.
        Vencida     // La factura no fue pagada a tiempo y está vencida.
    }
}
