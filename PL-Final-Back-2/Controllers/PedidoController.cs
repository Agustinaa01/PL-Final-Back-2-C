
using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Data.Interfaces;
using Agenda_Tup_Back.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_Tup_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        //}

        [HttpGet("pedido")]
        public IActionResult GetAllPedido()
        {
            try
            {
                int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
                return Ok(_pedidoRepository.GetAllPedido(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetPedidoById(int Id)
        {
            try
            {
                return Ok(_pedidoRepository.GetPedidoById(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreatePedido(PedidoForCreation dto, int id)
        {
            try
            {
                _pedidoRepository.CreatePedido(dto);
                return Created("Created", dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", dto);
        }

        [HttpPost("AddProducto")]
        public  IActionResult AddProducto(PedidoForUpdate dto)
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
