using LibraryAPI.Db;
using LibraryAPI.Models;
using LibraryAPI.Models.DTOs;
using LibraryAPI.Repository.IRepository;
using LibraryAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly ApiResponse _response;

        public UserController(IUserRepository repo) 
        {
            _repo = repo;
            _response = new ApiResponse();
        }

        private void CreateResponse(HttpStatusCode statusCode, string message, object? data = null, bool isSuccess = false)
        {
            _response.Data = data;
            _response.StatusCode = statusCode;
            _response.IsSuccess = isSuccess;
            _response.Message = message;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse>> Register(UserRegistrationDTO regDTO)
        {
            try
            {
                byte[] salt = PasswordUtils.GenerateSalt();
                string hashedPassword = PasswordUtils.HashPassword(regDTO.Password, salt);

                User user = new User()
                {
                    Name = regDTO.Name,
                    Email = regDTO.Email,
                    PasswordHash = hashedPassword,
                    PasswordSalt = salt
                };

                await _repo.RegisterUser(user);
                //await _db.Users.AddAsync(user);
                //await _db.SaveChangesAsync();

                CreateResponse(HttpStatusCode.OK, "Registration successfull", user, true);

                return Ok(_response);

            }
            catch (Exception ex)
            {
                CreateResponse(HttpStatusCode.InternalServerError, $"Registration failed: {ex.Message}");
                return BadRequest(_response);
            }
        }

        [HttpGet] 
        public async Task<ActionResult<ApiResponse>> GetAllUsers()
        {
            try
            {
                IEnumerable<User> users = await _repo.GetAllUsers();
                string message = users.Any() ? "All users retrieved" : "No users found";
                CreateResponse(HttpStatusCode.OK, message, users, true);
                return Ok(_response);
            }
            catch (Exception e)
            {
                CreateResponse(HttpStatusCode.InternalServerError, $"Could not get users: {e.Message}");
                return BadRequest(_response);
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
