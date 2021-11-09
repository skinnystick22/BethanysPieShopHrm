﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHrmShared;

namespace BethanysPieShopHrm.App.Service;

public interface IEmployeeDataService
{
    Task<IEnumerable<Employee>> GetAllEmployees();
    Task<Employee> GetEmployeeDetails(int employeeId);
    Task<Employee> AddEmployee(Employee employee);
    Task UpdateEmployee(Employee employee);
    Task DeleteEmployee(int employeeId);
}