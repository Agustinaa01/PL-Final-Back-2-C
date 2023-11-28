

using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Data.Interfaces;
using Agenda_Tup_Back.Data.Repository.Implementations;
using Agenda_Tup_Back.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agenda_Tup_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidoController(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }
        //[HttpGet]
        //public IActionResult GetAllPedido()
        //{
        //    int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
        //    return Ok(_pedidoRepository.GetAllPedido(userId));

        [HttpGet("pedido")]
        public IActionResult GetAllPedido()
        {
            try
            {
                if (!HttpContext.User.Identity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"));
                if (claim == null)
                {
                    return BadRequest("No claim containing 'nameidentifier' found.");
                }

                int userId = Int32.Parse(claim.Value);
                return Ok(_pedidoRepository.GetAllPedido(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet]
        [Route("{Id}")]

        public IActionResult GetPedidosByUserId(int Id)
        {
            try
            {
                return Ok(_pedidoRepository.GetPedidosByUserId(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetPedido/{Id}")]
        public IActionResult GetPedido(int id)
        {
            try
            {
                return Ok(_pedidoRepository.GetPedido(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreatePedido(PedidoForCreation dto)
        {
            try
            {
                var newPedido = _pedidoRepository.CreatePedido(dto);
                return Created("Created", newPedido);
            }
            catch (Exception ex)
            {
                // Manejo de excepción
                // Puedes hacer algo con la excepción, por ejemplo, loguearla
                Exception inner = ex.InnerException;

                // Devuelve un resultado apropiado para el error
                return BadRequest("Error al procesar la solicitud: " + ex.Message);
            }
        }



        [HttpPost("AddProducto")]
        public IActionResult AddProducto(PedidoForUpdate dto)
        {
            try
            {
                _pedidoRepository.AddProducto(dto);
                return Created("Created", dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", dto);
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult DeleteContactsById(int Id)
        {
            try
            {
                 _pedidoRepository.DeletePedido(Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
