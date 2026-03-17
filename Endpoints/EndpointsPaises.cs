public static class EndpointsPaises
{
    public static void MapPaisesEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/paises", (BibliotecaContext db) => 
        {
            return db.pais.ToList();
        });

        // Endpoint para obtener un país por ID
        app.MapGet("/paises/{id}", (int id, BibliotecaContext db) => 
        {
            var pais = db.pais.Find(id);
            return pais is not null ? Results.Ok(pais) : Results.NotFound();
        });

        app.MapPost("/paises", (Pais pais, BibliotecaContext db) =>
        {
            db.pais.Add(pais);
            db.SaveChanges();
        });
    }
}