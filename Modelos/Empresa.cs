using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Empresa
{
    [Key]
    public int Empresa_Id { get; set; }

    public DateTime Empresa_Fecha_Creacion { get; set; }

    public string? Empresa_Logo { get; set; }

    public string? Empresa_Nombre { get; set; }
    
    public string? Empresa_Pais_Origen { get; set; }

    public int Pais_Id { get; set; }

    [ForeignKey("Pais_Id")]
    public Pais? Empresa_Pais { get; set; }
}