using Mapster;
using MiniBank.Domain;
using MiniBank.CustomersSrv.Application.Dtos.Responses;
using MiniBank.CustomersSrv.Domain.Entities;

// Example: Register mapping in a static class or during startup
public static class MapsterConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<Customer, CustomerEntitiyResponse>
            .NewConfig()
            .Map(dest => dest.Id, src => src.EntityId);

        // Add more mappings as needed
        // TypeAdapterConfig<Customer, CustomerEntitiyResponse>.NewConfig()...
    }
}