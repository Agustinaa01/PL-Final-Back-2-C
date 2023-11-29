

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
        [AllowAnonymous]
        public IActionResult GetAllProducto()
        {
            //int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            return Ok(_productoRepository.GetAllProducto());
        }
 
        [HttpGet("{id}")]
        [AllowAnonymous]
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
        [Authorize]
        public IActionResult CreateProducto(ProductoForCreation dto)
        {
            try
            {
                //int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
                _productoRepository.CreateProducto(dto);
                return Created("Created", dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //return NoContent();
        }

        [HttpPut("{id}")]
        [AllowAnonymous]

        public IActionResult UpdateProducto(int id, ProductoForCreation dto)
        {
            try
            {
                var producto = _mapper.Map<Producto>(dto);

                if (id != producto.Id)
                {
                    return BadRequest("The provided ID in the request body does not match the ID in the URL.");
                }

                var productoItem = _productoRepository.GetProductoById(id);

                if (productoItem == null)
                {
                    return NotFound("Product not found with the specified ID.");
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
        [Authorize]
        public IActionResult DeleteProductoById(int Id)
        {
            try
            {
                var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"));
                if (role.Value == "SuperAdmin")
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
