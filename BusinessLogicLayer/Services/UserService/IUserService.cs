using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.UserService
{
    public interface IUserService
    {
        Task<ActionResult> GetAllUsers();

        Task<ActionResult> GetUser();

        Task<ActionResult> AddUser();

        Task<ActionResult> UpdateUser();

        Task<ActionResult> DeleteUser();
    }
}

