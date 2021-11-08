using BethanysPieShopHrmShared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BethanysPieShopHrm.Api.Data.EntityConfigurations
{
    public class JobCategoryEntityConfiguration : IEntityTypeConfiguration<JobCategory>
    {
        public void Configure(EntityTypeBuilder<JobCategory> builder)
        {
            builder.HasData(new JobCategory { JobCategoryId = 1, JobCategoryName = "Pie research" });
            builder.HasData(new JobCategory { JobCategoryId = 2, JobCategoryName = "Sales" });
            builder.HasData(new JobCategory { JobCategoryId = 3, JobCategoryName = "Management" });
            builder.HasData(new JobCategory { JobCategoryId = 4, JobCategoryName = "Store staff" });
            builder.HasData(new JobCategory { JobCategoryId = 5, JobCategoryName = "Finance" });
            builder.HasData(new JobCategory { JobCategoryId = 6, JobCategoryName = "QA" });
            builder.HasData(new JobCategory { JobCategoryId = 7, JobCategoryName = "IT" });
            builder.HasData(new JobCategory { JobCategoryId = 8, JobCategoryName = "Cleaning" });
            builder.HasData(new JobCategory { JobCategoryId = 9, JobCategoryName = "Bakery" });
        }
    }
}