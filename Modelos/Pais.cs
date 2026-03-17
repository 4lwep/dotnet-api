using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pais
{
    [Key]
    [Column("pais_id")]
    public int Pais_Id { get; set; }
    [Column("pais_nombre")]
    public string? Pais_Nombre { get; set; }
    [Column("pais_habitantes")]
    public int Pais_Habitantes { get; set; }
    [Column("pais_empresas")]
    public List<Empresa>? Pais_Empresas { get; set; }
}