using LibraryAPI.Models;
using LibraryAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> RegisterUser(User user);
        Task<bool> EmailExists(string email);
    }
}
