using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class TaskItem
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(128)]
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    [Required]
    public Project Project { get; set; } = default!;
    [Required]
    [ForeignKey(nameof(Project))]
    public int ProjectId { get; set; }
    public Employee? AssignedTo { get; set; }
    [ForeignKey(nameof(AssignedTo))]
    public int? AssignedToId { get; set; }
}