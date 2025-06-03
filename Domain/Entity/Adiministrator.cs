using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace minimal_api.Domain.Entitys;

public class Adiministrator
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Required]
    [StringLength(255)]
    public string Email { get; set; } = default!;

    [StringLength(50)]
    public string Password { get; set; } = default!;

    [StringLength(10)]
    public string Profile { get; set; } = default!;
}
