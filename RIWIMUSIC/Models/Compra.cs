namespace RIWIMUSIC.Models;

public class Compra
{
    public int Id { get; set; }
    public int ConciertoId { get; set; }
    public int ClienteId { get; set; }
    public int Cantidad { get; set; }
    public DateTime FechaCompra { get; set; }
}