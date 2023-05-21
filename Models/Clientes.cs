using System.ComponentModel.DataAnnotations;

public class Cliente{
    [Key]

    public int ClienteId { get; set; }

    public string Nombres { get; set; } = string.Empty;

    public string? Telefono { get; set; }

    public string? Celular { get; set; }

    public string RNC { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Direccion { get; set; } = string.Empty;
}