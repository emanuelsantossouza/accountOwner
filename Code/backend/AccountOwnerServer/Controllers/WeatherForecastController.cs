using Microsoft.AspNetCore.Mvc;
using Contracts;

namespace AccountOwnerServer.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private IRepositoryWrapper _repository;

    public WeatherForecastController(IRepositoryWrapper repository)
    { 
        _repository = repository;
    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
        var domesticAccount = _repository.Account
            .FindByCondition(x => x.AccountType.Equals("Domestic"));
        var owners = _repository.Owner.FindaAll();
        return new string[] { "Value1", "Value2"};
    }
   
}
