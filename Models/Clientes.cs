using System.ComponentModel.DataAnnotations;

public class Clientes{
    [Key]

    public int ClienteId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombres { get; set; } = string.Empty;

    [Required(ErrorMessage = "Es necesario agregar un numero de telefono")]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "El celular es obligatorio")]
    public string? Celular { get; set; }

    [Required(ErrorMessage = "El RNC es obligatorio")]
    public string RNC { get; set; } = string.Empty;

    [Required(ErrorMessage = "Es necesario agregar un numero de telefono")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Es necesario agregar una direccion")]
    public string Direccion { get; set; } = string.Empty;
}