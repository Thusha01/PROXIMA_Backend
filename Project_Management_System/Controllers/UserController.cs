﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X9;
using Project_Management_System.Data;
using Project_Management_System.DTOs;
using Project_Management_System.Models;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Project_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
       
        public UserController( DataContext dataContext, IMapper mapper)
        {         
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> RegisterUser(UserRegisterDto request)
        {
            var randomPassword = CreateRandomPassword(10);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(randomPassword);

            var existingUser = _dataContext.Users.FirstOrDefault(u => u.UserName == request.UserName);
            if (existingUser != null)
            {
                return BadRequest(new { message = "Username already exists" });
            }

            var userCategory = _dataContext.UsersCategories.FirstOrDefault(uc => uc.UserCategoryType == request.UserCategoryType);
            if (userCategory == null)
            {
                return BadRequest(new { message = "Invalid UserCategoryType" });
            }

            int UserCategoryId = userCategory.UserCategoryId;

            var jobRole = _dataContext.JobRoles.FirstOrDefault(jr => jr.JobRoleType == request.JobRoleType);
            if (jobRole == null)
            {
                return BadRequest(new { message = "Invalid jobRoleType" });
            }

            int JobRoleId = jobRole.JobRoleId;

            User newUser = new User
            {
                UserName = request.UserName,
                PasswordHash = passwordHash,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                Gender = request.Gender,
                NIC = request.NIC,
                DOB = request.DOB,
                ContactNumber = request.ContactNumber,
                Email = request.Email,
                JobRoleId = JobRoleId,
                UserCategoryId = UserCategoryId
            };

            _dataContext.Users.Add(newUser);
            await _dataContext.SaveChangesAsync();


            //return (randomPassword);

            // await SendPasswordEmail(request.Email, request.UserName, randomPassword);


            // Get the newly created user's UserId
            int newUserId = newUser.UserId;


            // Add the UserId to the relevant table based on UserCategoryType
            switch (request.UserCategoryType)
            {
                case "Admin":
                    var newAdmin = new Admin
                    {
                        AdminId = newUserId,
                        // Other Admin-specific properties can be set here if needed
                    };
                    _dataContext.Admins.Add(newAdmin);
                    break;

                case "Manager":
                    var newProjectManager = new ProjectManager
                    {
                        ProjectManagerId = newUserId,
                        // Other ProjectManager-specific properties can be set here if needed
                    };
                    _dataContext.ProjectManagers.Add(newProjectManager);
                    break;

                case "Developer":
                    var newDeveloper = new Developer
                    {
                        DeveloperId = newUserId,
                        FinanceReceiptId = 1,
                        TotalDeveloperWorkingHours = 0,
                        // Other Developer-specific properties can be set here if needed
                    };
                    _dataContext.Developers.Add(newDeveloper);
                    break;

                    // Add other cases for different user categories if needed
            }

            await _dataContext.SaveChangesAsync();

            return randomPassword;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ViewUserDetailDto>> GetById(int id)
        {
            var user = await _dataContext.Users
                .Include(u => u.UserCategory)
                .Include(u => u.JobRole)
                .FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            // Map the user data along with UserCategoryType and JobRoleType to ViewUserDetailDto
            var viewUserDto = new ViewUserDetailDto
            {
                UserId = user.UserId,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Gender = user.Gender,
                NIC = user.NIC,
                DOB = user.DOB,
                // ProfilePictureLink = user.ProfilePictureLink,
                IsActive = user.IsActive,
                ContactNumber = user.ContactNumber,
                Email = user.Email,
                UserCategoryType = user.UserCategory?.UserCategoryType,
                JobRoleType = user.JobRole?.JobRoleType
            };

            return Ok(viewUserDto);
        }

        [HttpGet("list")]
        public ActionResult<IEnumerable<ViewUserListDto>> GetAll()
        {
            var users = _dataContext.Users
                .Include(u => u.UserCategory)
                .ToList();

            // Map each user to ViewUserListDto
            var viewUserListDtos = users.Select(user => new ViewUserListDto
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                UserCategoryType = user.UserCategory != null ? user.UserCategory.UserCategoryType : null
            }).ToList();

            return Ok(viewUserListDtos);
        }

        [HttpPost("deactivate-user")]
        public async Task<IActionResult> DeactivateUser([FromBody] DeactivateUserDto request)
        {
            // Fetch the user from the database using the username
            var user = _dataContext.Users.FirstOrDefault(u => u.UserId == request.UserId);

            // Check if the user exists
            if (user == null)
            {
                return BadRequest(new { message = "User not found." });
            }

            if (user.IsActive == false)
            {
                return BadRequest(new { message = "User already deactivated from the system." });
            }

            user.IsActive = false;

            // Save the changes to the database
            _dataContext.Users.Update(user);
            await _dataContext.SaveChangesAsync();

            return Ok(new { message = "User successfully deactivate.!"});
        }

        [HttpGet("search")]
        public ActionResult<List<ViewUserListDto>> SearchUsers([FromQuery] string term)
        {
            // If the term is empty, return a bad request
            if (string.IsNullOrWhiteSpace(term))
            {
                return BadRequest(new { message = "Search term cannot be empty" });
            }

            // Convert term to lowercase for case-insensitive comparison
            term = term.ToLower();

            var users = _dataContext.Users
                .Where(u => u.UserId.ToString().ToLower().Contains(term) ||
                            u.UserName.ToLower().Contains(term) ||
                            u.UserCategory.UserCategoryType.ToLower().Contains(term))
                .Select(u => new ViewUserListDto
                {
                    UserId = u.UserId,
                    UserName = u.UserName,
                    Email = u.Email,
                    UserCategoryType = u.UserCategory.UserCategoryType
                })
                .ToList();

            if (users == null || users.Count == 0)
            {
                return NotFound(new { message = "No users found" });
            }

            return Ok(users);
        }



        public static string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }

       
    }
}



