using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Employee
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(64)]
    public string Name { get; set; } = default!;
    [Required]
    public Manager Superior { get; set; } = default!;
    [Required]
    [ForeignKey(nameof(Superior))]
    public int SuperiorId { get; set; }
}