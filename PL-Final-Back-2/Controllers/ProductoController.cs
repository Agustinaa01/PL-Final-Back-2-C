

using System.Security.Claims;
using Agenda_Tup_Back.Data.Interfaces;
using Agenda_Tup_Back.DTO;
using Agenda_Tup_Back.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_Tup_Back.Controllers
{
    [Route("api/[controller]")] //api/Nombre del controlador
    [ApiController]
    [Authorize]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ProductoController(IProductoRepository productoRepository, IUserRepository userRepository, IMapper autoMapper)
        {
            _productoRepository = productoRepository;
            _userRepository = userRepository;
            _mapper = autoMapper;
        }
        [HttpGet]
        public IActionResult GetAllProducto()
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            return Ok(_productoRepository.GetAllProducto(userId));
        }
 
        [HttpGet("{id}")]
        public IActionResult GetProductoById(int id)
        {
            try
            {

                var producto = _productoRepository.GetProductoById(id);

                if (producto == null)
                {
                    return NotFound();
                }

                var productoDto = _mapper.Map<ProductoForCreation>(producto);

                return Ok(productoDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateProducto(ProductoForCreation dto)
        {
            try
            {
                int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
                _productoRepository.CreateProducto(dto, userId);
                return Created("Created", dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProducto(int id, ProductoForCreation dto)
        {
            try
            {
                var producto = _mapper.Map<Producto>(dto);

                if (id != producto.Id)
                {
                    return NotFound();
                }

                var productoItem = _productoRepository.GetProductoById(id);

                if (productoItem == null)
                {
                    return NotFound();
                }

                _productoRepository.UpdateProducto(producto);

                var productoModificado = _productoRepository.GetProductoById(id);

                var productoModificadoDto = _mapper.Map<ProductoForCreation>(productoModificado);

                return Ok(productoModificadoDto);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult DeleteProductoById(int Id)
        {
            try
            {
                var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"));
                if (role.Value == "Admin")
                {
                    _productoRepository.DeleteProducto(Id);
                }
                else
                {
                    _productoRepository.ArchiveProducto(Id);
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
