using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHrmShared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHrm.App.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter] public string EmployeeId { get; set; }

        public Employee Employee { get; set; } = new();

        public IEnumerable<Employee> Employees { get; set; }

        private List<Country> Countries { get; set; }

        private List<JobCategory> JobCategories { get; set; }

        protected override Task OnInitializedAsync()
        {
            InitializeCountries();
            InitializeJobCategories();
            InitializeEmployees();

            Employee = Employees.FirstOrDefault(e => e.EmployeeId == int.Parse(EmployeeId));

            return base.OnInitializedAsync();
        }

        private void InitializeJobCategories()
        {
            JobCategories = new List<JobCategory>
            {
                new() { JobCategoryId = 1, JobCategoryName = "Pie research" },
                new() { JobCategoryId = 2, JobCategoryName = "Sales" },
                new() { JobCategoryId = 3, JobCategoryName = "Management" },
                new() { JobCategoryId = 4, JobCategoryName = "Store staff" },
                new() { JobCategoryId = 5, JobCategoryName = "Finance" },
                new() { JobCategoryId = 6, JobCategoryName = "QA" },
                new() { JobCategoryId = 7, JobCategoryName = "IT" },
                new() { JobCategoryId = 8, JobCategoryName = "Cleaning" },
                new() { JobCategoryId = 9, JobCategoryName = "Bakery" },
                new() { JobCategoryId = 9, JobCategoryName = "Bakery" }
            };
        }

        private void InitializeCountries()
        {
            Countries = new List<Country>
            {
                new() { CountryId = 1, Name = "Belgium" },
                new() { CountryId = 2, Name = "Netherlands" },
                new() { CountryId = 3, Name = "USA" },
                new() { CountryId = 4, Name = "Japan" },
                new() { CountryId = 5, Name = "China" },
                new() { CountryId = 6, Name = "UK" },
                new() { CountryId = 7, Name = "France" },
                new() { CountryId = 8, Name = "Brazil" }
            };
        }

        private void InitializeEmployees()
        {
            var e1 = new Employee
            {
                CountryId = 1,
                MaritalStatus = MaritalStatus.Single,
                BirthDate = new DateTime(1989, 3, 11),
                City = "Brussels",
                Email = "bethany@bethanyspieshop.com",
                EmployeeId = 1,
                FirstName = "Bethany",
                LastName = "Smith",
                Gender = Gender.Female,
                PhoneNumber = "324777888773",
                Smoker = false,
                Street = "Grote Markt 1",
                Zip = "1000",
                JobCategoryId = 1,
                Comment = "Lorem Ipsum",
                ExitDate = null,
                JoinedDate = new DateTime(2015, 3, 1)
            };

            var e2 = new Employee
            {
                CountryId = 2,
                MaritalStatus = MaritalStatus.Married,
                BirthDate = new DateTime(1979, 1, 16),
                City = "Antwerp",
                Email = "gill@bethanyspieshop.com",
                EmployeeId = 2,
                FirstName = "Gill",
                LastName = "Cleeren",
                Gender = Gender.Female,
                PhoneNumber = "33999909923",
                Smoker = false,
                Street = "New Street",
                Zip = "2000",
                JobCategoryId = 1,
                Comment = "Lorem Ipsum",
                ExitDate = null,
                JoinedDate = new DateTime(2017, 12, 24)
            };
            Employees = new List<Employee> { e1, e2 };
        }
    }
}