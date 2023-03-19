using Entities.Models;
namespace Contracts;

public interface IOwnerRepository : IRepositoryBase<Owner>
{
    IEnumerable<Owner> GetAllOwners();
    Owner GetOwnerById(Guid ownerId);
    Owner GetOwnerWithDetails(Guid ownerId);
}
