using System.ComponentModel.DataAnnotations;
namespace Entities.DataTransferObjects;

public class OwnerForUpdateDto
{
    [Required(ErrorMessage = "Campo Obrigatório: Nome")]
    [StringLength(60, ErrorMessage = "O Nome não pode ter mais de 60 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório: Data de Nascimento")]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório: Endereço")]
    [StringLength(60, ErrorMessage = "O Endereço não pode ter mais de 100 caracteres")]
    public string Address { get; set; }
}