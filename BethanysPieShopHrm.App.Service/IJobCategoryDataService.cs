using BethanysPieShopHrmShared;

namespace BethanysPieShopHrm.App.Service;

public interface IJobCategoryDataService
{
    Task<IEnumerable<JobCategory>> GetAllJobCategories();
    Task<JobCategory> GetJobCategoryById(int jobCategoryId);
}