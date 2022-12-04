using Application.Contracts.Persistence;
using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services;

public class Service : IService
{
    private readonly AppDbContext _context;

    public Service(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProjectSummaryVM>> GetAllProjects()
    {
        return await _context.Projects
            .Include(p => p.Manager)
            .Include(p => p.TaskItems)
            .Select(p => new ProjectSummaryVM
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                ManagerName = p.Manager.Name,
                NumberOfTasks = p.TaskItems.Count
            })
            .ToListAsync();
    }
}