using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<ActionResult> GetAllEmployees();

        Task<ActionResult> GetEmployee();

        Task<ActionResult> AddEmployee();

        Task<ActionResult> UpdateEmployee();

        Task<ActionResult> DeleteEmployee();
    }
}
