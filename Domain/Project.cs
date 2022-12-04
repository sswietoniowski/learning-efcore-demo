using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Project
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(128)]
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    [Required]
    public Manager Manager { get; set; } = default!;
    [Required]
    [ForeignKey(nameof(Manager))]
    public int ManagerId { get; set; }
    public List<TaskItem> TaskItems { get; set; } = new();
}