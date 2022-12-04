using WebUI.Models;

namespace WebUI.Repository;

public interface IService
{
    Task<IEnumerable<ProjectSummaryVM>> GetAllProjects();
}