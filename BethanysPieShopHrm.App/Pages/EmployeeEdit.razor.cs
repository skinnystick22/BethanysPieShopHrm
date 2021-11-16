using BethanysPieShopHrm.App.Service;
using BethanysPieShopHrmShared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHrm.App.Pages;

public partial class EmployeeEdit
{
    [Inject] public IEmployeeDataService EmployeeDataService { get; set; }
    [Inject] public ICountryDataService CountryDataService { get; set; }
    [Inject] public IJobCategoryDataService JobCategoryDataService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    [Parameter] public string EmployeeId { get; set; }

    public Employee Employee { get; set; } = new();

    public List<Country> Countries { get; set; } = new();
    public List<JobCategory> JobCategories { get; set; } = new();

    public string CountryId { get; set; }
    public string JobCategoryId { get; set; }

    public string Message { get; set; }
    public string StatusClass { get; set; }
    public bool Saved { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Saved = false;

        int.TryParse(EmployeeId, out var employeeId);

        if (employeeId == 0)
        {
            Employee = new Employee
            {
                CountryId = 1,
                JobCategoryId = 1,
                BirthDate = DateTime.Now,
                JoinedDate = DateTime.Now
            };
        }
        else
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(employeeId);
        }

        Countries = (await CountryDataService.GetAllCountries()).ToList();
        CountryId = Employee.CountryId.ToString();
        JobCategories = (await JobCategoryDataService.GetAllJobCategories()).ToList();
        JobCategoryId = Employee.JobCategoryId.ToString();
    }

    private async Task HandleValidSubmit()
    {
        Saved = false;
        Employee.CountryId = int.Parse(CountryId);
        Employee.JobCategoryId = int.Parse(JobCategoryId);

        if (Employee.EmployeeId == 0)
        {
            var addedEmployee = await EmployeeDataService.AddEmployee(Employee);
            if (addedEmployee != null)
            {
                StatusClass = "alert-success";
                Message = "New Employee added Successfully.";
                Saved = true;
            }
            else
            {
                StatusClass = "alert-danger";
                Message = "Something went wrong adding the new employee. Please try again.";
                Saved = false;
            }
        }
        else
        {
            await EmployeeDataService.UpdateEmployee(Employee);
            StatusClass = "alert-success";
            Message = "Employee updated successfully.";
            Saved = true;
        }
    }

    private void HandleInvalidSubmit()
    {
        StatusClass = "alert-danger";
        Message = "There are some validation errors. Please try again";
    }

    private async Task DeleteEmployee()
    {
        await EmployeeDataService.DeleteEmployee(Employee.EmployeeId);

        StatusClass = "alert-success";
        Message = "Deleted successfully";
        Saved = true;
    }

    private void NavigateToOverview()
    {
        NavigationManager.NavigateTo($"/{nameof(EmployeeOverview)}");
    }
}