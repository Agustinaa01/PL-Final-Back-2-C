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
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper autoMapper) //en el contructor de dicha entre parentesis 
        {
            _userRepository = userRepository;
            _mapper = autoMapper;
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetAllUser()
        {
            return Ok(_userRepository.GetAllUsers());
        }

        [HttpGet]
        [Route("{Id}")]
        [Authorize]
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
        [AllowAnonymous]
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

        [HttpPut("{id}")]
        [AllowAnonymous]

        public IActionResult UpdateUser(int id, UserForUpdate dto)
        {
            try
            {
                var userItem = _userRepository.GetUserById(id);

                if (userItem == null)
                {
                    return NotFound("Product not found with the specified ID.");
                }

                if (id != dto.Id)
                {
                    return BadRequest("The provided ID in the request body does not match the ID in the URL.");
                }

                userItem.Name = dto.Name;
                userItem.Password = dto.Password;
                userItem.Email = dto.Email;

                _userRepository.UpdateUser(userItem);

                var userModificado = _userRepository.GetUserById(id);

                var userModificadoDto = _mapper.Map<UserForCreation>(userModificado);

                return Ok(userModificadoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("{Id}")]
        [Authorize]
        public IActionResult DeleteUsersById(int Id)
        {
            try
            {
                var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"));
                if (role.Value == "SuperAdmin")
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

