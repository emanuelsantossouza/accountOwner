using Entities.Models;

namespace Contracts;

public interface IAccountRepository : IRepositoryBase<Account>
{
    IEnumerable<Account> AccountsByOwner(Guid ownerId);
}
