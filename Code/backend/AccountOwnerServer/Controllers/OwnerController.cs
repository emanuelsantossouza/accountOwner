using AutoMapper;
using Contracts;
using Entities.Models;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OwnerController : ControllerBase 
{
    private ILoggerManager _logger;
    private IRepositoryWrapper _repository;
    private IMapper _mapper;

    public OwnerController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    } 

    [HttpGet]
    public IActionResult GetAllOwners()
    {
        try
        {
            var owner = _repository.Owner.GetAllOwners();
            _logger.LogInfo($"Retornando todos os owners do banco de dados.");

            var ownersResults = _mapper.Map<IEnumerable<OwnerDto>>(owners);
            return Ok(ownersResults);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu um erro no método GetAllOwners: {ex.Message}");
            return StatusCode(500, "Erro Interno do Servidor");
        }
    }

    [HttpGet("{id}", Name = "OwnerById")]
    public IActionResult GetOwnerById(Guid id)
    {
        try
        {
            var owner = _repository.Owner.GetOwnerById(id);

            if (owner is null)
            {
                _logger.LogError($"Owner com Id: {id}, não encotrado.");
                return NotFound();
            } else {
                _logger.LogInfo($"Retornando o owner com Id: {id}");
                return Ok(ownersResults);
            }
        }
        catch (Exception ex){
            _logger.LogError($"Ocorreu um erro no método GetOwnerById: {ex.Message}");
            return StatusCode(500, "Erro Interno do Servidor");
        }
    }

    [HttpGet("{id}/account")]
    public IActionResult GetOwnerWithDetails(Guid id)
    {
        try
        {
            var owner = _repository.Onwer.GetOwnerWithDetails(id);
            if (owner == null)
            {
                _logger.LogError($"Owner com Id: {id}, não encontrado.");
                return NotFound();
            } else {
                _logger.LogInfo($"Retornando o owner com detalhes e Id: {id}");

                var ownerResults = mapper.Map<OwnerDto>(owner);
                return Ok(ownerResult);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu um erro no método GetOwnerWithDetails: {ex.Message}");
            return StatusCode(500, "Erro Interno do Servidor");
        }
    }

    [HttpPost]
    public IActionResult CreateOwner([FromBody] OwnerForCreationDto owner)
    {
        try
        {
            if(owner is null) 
            {
                _logger.LogError("Objeto Onwer enviado está nulo.");
                return BadResquest("Objeto Owner é nulo");
            }

            if (!ModelState.IsValid)
                {
                    _logger.LogError("Objeto owner enviado é inválido.");
                    return BadResquest("Objeto de modelo inválido");
                }

                var ownerEntity = _mapper.Map<Owner>(owner);

                _repository.Owner.CreateOwner(ownerEntity);
                _repository.Save();

                var createdOwner = _mapper.Map<OwnerDto>(ownerEntity);

                return CreatedAtRoute("OwnerById", new { id = createdOwner.Id}, createdOwner);    
        } 
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu um erro no método CreateOwner: {ex.Message}");
            return StatusCode(500, "Erro Interno do Servidor");
        }
    }

}
