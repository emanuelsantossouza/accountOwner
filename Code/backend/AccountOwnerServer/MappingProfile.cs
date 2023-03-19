using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace AccountOwnerServer;

public class MappingProfile 
{
    public MappingProfile()
    {
        CreateMap<Owner, OwnerDto>();
    }
}
