using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("owner")]
 public class Owner
{
  [Column("OwnerId")] 
    public Guid Id { get; set; }

    [Required] // (ErrorMessage = "Digite a porra do Nome")]
    [StringLength(60)]
    public string? Name { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [StringLength(100)]
    public string? Adress { get; set; }

    public ICollection<Account>? Accounts { get; set; } // Relacionamento de 1 para muitos
}
