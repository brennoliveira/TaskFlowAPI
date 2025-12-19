using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Entities;
using TaskFlow.Application.Services.Auth;
using TaskFlow.Application.DTOs;
using TaskFlow.Infrastructure.Interfaces;
using TaskFlow.Application.Interfaces;
using TaskFlow.CrossCutting.Exceptions;

namespace TaskFlow.Application.Services
{
    public class UserService(IUserRepository userRepository, JwtService jwtService) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly JwtService _jwtService = jwtService;

        public async Task RegisterAsync(RegisterUserDTO dto)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                throw new ConflictException("Email already registered.");
            }

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            };

            await _userRepository.AddAsync(user);
        }

        public async Task<string> LoginAsync(LoginUserDTO dto)
        {
            var user = await _userRepository.GetUserByEmailAsync(dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                throw new UnauthorizedException("Invalid email or password.");
            }

            return _jwtService.GenerateToken(user.Id, user.Email);
        }
    }
}
