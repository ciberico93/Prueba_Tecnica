using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI_PruebaTecnica.Context;
using WebAPI_PruebaTecnica.Models;
using WebAPI_PruebaTecnica.Repositories.IRepositories;

namespace WebAPI_PruebaTecnica.Repositories
{
    public class CargoRepository : IRepositoryBase<Cargo>
    {

        private readonly DbcrudcoreContext _context;
        private readonly DbSet<Cargo> _dbset;


        public CargoRepository(DbcrudcoreContext context)
        {
            _dbset = context.Set<Cargo>();
            _context = context;

        }

        public async Task<Cargo> CreateAsync(Cargo entity)
        {
            Cargo cargo = new Cargo()
            {
                Descripcion = entity.Descripcion
            };

            EntityEntry <Cargo> result = await _dbset.AddAsync(cargo);
            await _context.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            Cargo entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Cargo>> GetAll()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<Cargo> GetByIdAsync(int id)
        {
            return await _dbset.FirstAsync(p => p.IdCargo == id);
        }

        public async Task<Cargo> UpdateAsync(Cargo entity)
        {
            var cargo = await GetByIdAsync(entity.IdCargo);
            if (cargo == null)
            {
                return null;
            }
            cargo.Descripcion = entity.Descripcion;

            await _context.SaveChangesAsync();
            return cargo;
        }
    }
}
