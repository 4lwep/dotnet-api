public static class MapEndpoints
{
    public static void MapAllEndpoints(IEndpointRouteBuilder app)
    {
        EndpointsEmpresas.MapEmpresasEndpoint(app);
        EndpointsPaises.MapPaisesEndpoint(app);
    }
}