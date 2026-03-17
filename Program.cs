using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), 
        npgsqlOptions => npgsqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", "biblioteca")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

/*using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BibliotecaContext>();

    var empresa = new Empresa()
    {
        Empresa_Fecha_Creacion = DateTime.UtcNow,
        Empresa_Logo = "",
        Empresa_Nombre = "Siscom",
        Empresa_Pais_Origen = "España"
    };

    //context.empresa.Update(empresa);  //Para esto hay que poner el Id para que sepa que empresa modificar
    //context.SaveChanges();

    context.empresa.Add(empresa);
    context.SaveChanges();

    var empresas = context.empresa.ToList();

    Console.WriteLine("Tipo: " + context.empresa.GetType());

    empresas.ForEach((empresa) =>
    {
        Console.WriteLine("---Empresas---" + empresa.Empresa_Id + ": " + empresa.Empresa_Nombre);
    });

    //Console.WriteLine(context.empresa.First().Empresa_Nombre);

    Console.WriteLine("Empresa con id 1: " + context.empresa.Where((e) => e.Empresa_Id == 1).ToList()[0].Empresa_Nombre);

    var query = context.empresa.GroupBy(e => e.Empresa_Id % 2 == 0 ? "Pares" : "Impares");
    query.ToList().ForEach((e) => {
        //Console.WriteLine(e.Key + " | " + e.Select(emp => emp.Empresa_Nombre));
        Console.WriteLine(e.Key);
        Console.WriteLine(string.Join(", ", e.Select(emp => emp.Empresa_Nombre)));
    });

}*/

// Endpoint para obtener todas las empresas
MapEndpoints.MapAllEndpoints(app);

app.Run();