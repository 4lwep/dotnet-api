using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Empresa
{
    [Key]
    [Column("empresa_id")]
    public int Empresa_Id { get; set; }

    [Column("empresa_fecha_creacion")]
    public DateTime Empresa_Fecha_Creacion { get; set; }

    [Column("empresa_logo")]
    public string? Empresa_Logo { get; set; }

    [Column("empresa_nombre")]
    public string? Empresa_Nombre { get; set; }
    
    [Column("empresa_pais_origen")]
    public string? Empresa_Pais_Origen { get; set; }

    [Column("pais")]
    public Pais? Empresa_Pais { get; set; }
}