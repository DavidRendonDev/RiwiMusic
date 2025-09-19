namespace RIWIMUSIC.Models;

public class Concierto
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Artista { get; set; } 
    public DateTime Fecha { get; set; }
    public string? Lugar  { get; set; }
    public decimal Precio { get; set; }
}