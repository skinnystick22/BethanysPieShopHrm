using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHrm.App.Service;
using BethanysPieShopHrmShared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHrm.App.Pages;

public partial class EmployeeOverview
{
    [Inject]
    public IEmployeeDataService EmployeeDataService { get; set; }

    public IEnumerable<Employee> Employees { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Employees = await EmployeeDataService.GetAllEmployees();
    }
}