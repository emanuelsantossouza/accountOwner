using NLog;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
    private readonly ILoggerManager _logger;
        
    public LogsController(ILoggerManager logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
        _logger.LogInfo("Testando o log de Info");
        _logger.LogDebug("Testando o log de DeBug");
        _logger.LogError("Testando o log de Erro");
        _logger.LogWarn("Testando o log de Aviso");
        return new string[]
        {
           "Emanuel Gostoso",
           "Gallo..."
        };
    }
    }
}