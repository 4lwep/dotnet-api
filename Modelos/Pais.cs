using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pais
{
    [Key]
    public int Pais_Id { get; set; }
    public string? Pais_Nombre { get; set; }
    public int Pais_Habitantes { get; set; }
    public List<Empresa>? Pais_Empresas { get; set; }
}