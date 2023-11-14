using Microsoft.AspNetCore.Mvc;
using WebAPI_PruebaTecnica.Models;
using WebAPI_PruebaTecnica.Repositories.IRepositories;

namespace WebAPI_PruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : Controller
    {

        private readonly IRepositoryBase<Empleado> _repository;

        public EmpleadoController(IRepositoryBase<Empleado> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEmpleado()
        {
            var empleado = await _repository.GetAll();
            return Ok(empleado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var empleado = await _repository.GetByIdAsync(id);
            return Ok(empleado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Empleado))]
        public async Task<IActionResult> CreateEmpleado(Empleado empleado)
        {
            Empleado result = await _repository.CreateAsync(empleado);

            return new CreatedResult($"https://localhost:7051/api/Empleado/{result.IdEmpleado}", null);
        }

        [HttpDelete("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return new OkObjectResult(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Empleado))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateEmpleado(Empleado empleado)
        {
            Empleado result = await _repository.UpdateAsync(empleado);

            if (result == null)
            {
                return new NotFoundResult();
            }

            else
            {
                return new OkObjectResult(result);
            }
        }













        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
