using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Empresa, EmpresaDTO>();

        CreateMap<EmpresaDTO, Empresa>();
        
        CreateMap<Pais, PaisDTO>();

        CreateMap<PaisDTO, Pais>();
    }
}