using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTOs;

namespace TaskFlow.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterUserDTO dto);
        Task<string> LoginAsync(LoginUserDTO dto);
    }
}
