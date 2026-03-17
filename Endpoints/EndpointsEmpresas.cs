using Microsoft.EntityFrameworkCore;

public static class EndpointsEmpresas
{
    public static void MapEmpresasEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/empresas", (BibliotecaContext db) => 
        {
            return db.empresa.ToList();
        });

        // Endpoint para obtener una empresa por ID
        app.MapGet("/empresas/{id}", (int id, BibliotecaContext db) => 
        {
            var empresa = db.empresa.Find(id);
            return empresa is not null ? Results.Ok(empresa) : Results.NotFound();
        });

        app.MapPost("/empresas", (Empresa empresa, BibliotecaContext db) =>
        {
            empresa.Empresa_Fecha_Creacion = DateTime.SpecifyKind(empresa.Empresa_Fecha_Creacion, DateTimeKind.Utc);
            //empresa.Empresa_Pais = db.pais.Find(empresa.Empresa_Pais);
            db.empresa.Add(empresa);
            db.SaveChanges();
        });

        app.MapGet("/empresas/pais/{pais}", (string pais, BibliotecaContext db) =>
        {
            var empresas = db.empresa.AsNoTracking().Where(e => e.Empresa_Pais_Origen == pais);
            return empresas;
        });

        app.MapGet("/paises_old", (BibliotecaContext db) =>
        {
            var paises = db.empresa.AsNoTracking().Select(e => e.Empresa_Pais_Origen).Distinct();
            return paises;
        });

        /*app.MapPost("/empresas/agregar-pais", (Empresa empresa, Pais pais, BibliotecaContext db) =>
        {
            
        });*/

        /*
        Seguimiento: se quita con .AsNoTracking() y sirve para poder comparar la base de datos con los cambios realizados antes del savechanges
        Lo normal es desactivarlo para lectura y activarlo para edición (si no, no se guardan los cambios), sin embargo hay motivos para no cumplir esto.
        Por ejemplo en edición se puede desactivar para ahorrar recursos y se peuden buscar alternativas coomo hacer la consulta sql directamente 
        o user ExecuteUpdate() ya que se guarda automáticamente y es más eficiente:

        // Ejemplo: Cambiar el nombre de todas las empresas de "España" a "España S.A."
        // SIN cargar nada en memoria, SIN tracking, SIN recorrer la lista.
        int filasAfectadas = await db.empresa
            .Where(e => e.Empresa_Pais_Origen == "España")
            .ExecuteUpdateAsync(setters => setters
        .SetProperty(e => e.Empresa_Nombre, "España S.A."));

        Para la lectura, se podría usar seguimiento porque está sincronizado con los cambios realizados pero no guardados, es decir,
        si hago una modificación con seguimiento y antes de guardarla intento leer datos de esa modificación, si la lectura es con seguimiento 
        leerá los nuevos datos aunque aún no estén en la base de datos 
        */
    }
}