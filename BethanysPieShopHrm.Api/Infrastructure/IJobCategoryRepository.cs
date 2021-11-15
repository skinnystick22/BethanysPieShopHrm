using BethanysPieShopHrmShared;

namespace BethanysPieShopHrm.Api.Infrastructure;

public interface IJobCategoryRepository
{
    IEnumerable<JobCategory> GetAllJobCategories();
    JobCategory GetJobCategoryById(int jobCategoryId);
}