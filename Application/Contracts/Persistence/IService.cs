using Application.Models;

namespace Application.Contracts.Persistence;

public interface IService
{
    Task<IEnumerable<ProjectSummaryVM>> GetAllProjectsAsync();
}