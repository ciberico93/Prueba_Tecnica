using Microsoft.AspNetCore.Mvc;
using WebAPI_PruebaTecnica.Models;
using WebAPI_PruebaTecnica.Repositories.IRepositories;

namespace WebAPI_PruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CargoController : Controller
    {
        private readonly IRepositoryBase<Cargo> _cargoRepository;

        public CargoController(IRepositoryBase<Cargo> cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCargo() 
        {
            var cargo = await _cargoRepository.GetAll();
            return Ok(cargo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cargo = await _cargoRepository.GetByIdAsync(id);
            return Ok (cargo);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Cargo))]
        public async Task<IActionResult> CreateCargo(Cargo cargo)
        {
            Cargo result = await _cargoRepository.CreateAsync(cargo);

            return new CreatedResult($"https://localhost:7051/api/Empleado/{result.IdCargo}", null);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            var result = await _cargoRepository.DeleteAsync(id); 
            return new OkObjectResult(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Cargo))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCargo(Cargo cargo)
        {
            Cargo result = await _cargoRepository.UpdateAsync(cargo);
            if (result == null)
            {
                return new NotFoundResult();
            }
            else
            {
                return new OkObjectResult(result);
            }
        }


    }
}
