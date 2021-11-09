using BethanysPieShopHrmShared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BethanysPieShopHrm.Api.Data.EntityConfigurations;

public class JobCategoryEntityConfiguration : IEntityTypeConfiguration<JobCategory>
{
    public void Configure(EntityTypeBuilder<JobCategory> builder)
    {
        builder.HasKey(jc => jc.JobCategoryId)
            .IsClustered();

        builder.HasIndex(jc => jc.JobCategoryName)
            .IsUnique();

        builder.HasData(
            new JobCategory {JobCategoryId = 1, JobCategoryName = "Pie research"},
            new JobCategory {JobCategoryId = 2, JobCategoryName = "Sales"},
            new JobCategory {JobCategoryId = 3, JobCategoryName = "Management"},
            new JobCategory {JobCategoryId = 4, JobCategoryName = "Store staff"},
            new JobCategory {JobCategoryId = 5, JobCategoryName = "Finance"},
            new JobCategory {JobCategoryId = 6, JobCategoryName = "QA"},
            new JobCategory {JobCategoryId = 7, JobCategoryName = "IT"},
            new JobCategory {JobCategoryId = 8, JobCategoryName = "Cleaning"},
            new JobCategory {JobCategoryId = 9, JobCategoryName = "Bakery"}
        );
    }
}