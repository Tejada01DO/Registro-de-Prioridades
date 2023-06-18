using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Tickets
{
    [Key]

    public int TicketId { get; set; }

    public DateTime Fecha { get; set; } = DateTime.Today;

    [ForeignKey("ClienteId")]
    public int ClienteId { get; set; }

    [ForeignKey("SistemaId")]
    public int SistemaId { get; set; }

    [ForeignKey("PrioridadId")]
    public int PrioridadId { get; set; } 

    [Required(ErrorMessage = "Es necesario especificar por quien fue solicitado")]
    public string? SolicitadoPor { get; set; }

    [Required(ErrorMessage = "Es necesario especificar el asunto")]
    public string? Asunto { get; set; }

    [Required(ErrorMessage = "Es necesario dar una descripcion")]
    public string? Descripcion { get; set; }
    public List<TicketsDetalle> TicketDetalle { get; set; } = new List<TicketsDetalle>();

}