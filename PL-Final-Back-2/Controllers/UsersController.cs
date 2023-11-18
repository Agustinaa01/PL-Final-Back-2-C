using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Data.Interfaces;
using Agenda_Tup_Back.Data.Repository;
using Agenda_Tup_Back.Data.Repository.Implementations;
using Agenda_Tup_Back.DTO;
using Agenda_Tup_Back.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Agenda_Tup_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository) //en el contructor de dicha entre parentesis 
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult GetAllUser()
        {
            return Ok(_userRepository.GetAllUsers());
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetUserById(int Id)
        {

            try
            {
                return Ok(_userRepository.GetUserById(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateUser(UserForCreation dto)
        {
            try
            {
                _userRepository.CreateUsers(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", dto);
        }


        [HttpDelete]
        [Route("{Id}")]
        public IActionResult DeleteUsersById(int Id)
        {
            try
            {
                var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"));
                if (role.Value == "Admin")
                {
                    _userRepository.DeleteUsers(Id);
                }
                else
                {
                    _userRepository.ArchiveUsers(Id);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

