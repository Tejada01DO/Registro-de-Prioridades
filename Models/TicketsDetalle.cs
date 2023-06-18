using System.ComponentModel.DataAnnotations;

public class TicketsDetalle
{
    [Key]

    public int Id { get; set; }

    [Required(ErrorMessage = "Es necesario especificar un mensaje")]
    public int TicketId { get; set; }

    [Required(ErrorMessage = "Es necesario especificar un emisor")]
    public string Emisor { get; set; } = string.Empty;

    [Required(ErrorMessage = "Es necesario especificar un mensaje")]
    public string Mensaje { get; set; } = string.Empty;
}