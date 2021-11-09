using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHrm.App.Service;
using BethanysPieShopHrmShared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHrm.App.Pages;

public partial class EmployeeDetail
{
    [Inject] public IEmployeeDataService EmployeeDataService { get; set; }

    [Parameter] public string EmployeeId { get; set; }

    public Employee Employee { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
    }
}