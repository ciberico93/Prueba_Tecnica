using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI_PruebaTecnica.Context;
using WebAPI_PruebaTecnica.Models;
using WebAPI_PruebaTecnica.Repositories.IRepositories;

namespace WebAPI_PruebaTecnica.Repositories
{
    public class EmpleadoRepository : IRepositoryBase<Empleado>
    {
        private readonly DbSet<Empleado> _dbSet;
        private readonly DbcrudcoreContext _context;

        public EmpleadoRepository(DbcrudcoreContext context)
        {
            _dbSet = context.Set<Empleado>();
            _context = context;
        }

        public async Task<Empleado> CreateAsync(Empleado entity)
        {
            Empleado empleado = new Empleado()
            {
                NombreCompleto = entity.NombreCompleto,
                Correo = entity.Correo,
                Telefono = entity.Telefono,
                IdCargo = entity.IdCargo
            };

            EntityEntry<Empleado> result = await _dbSet.AddAsync(empleado);
            await _context.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            Empleado entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Empleado>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Empleado> GetByIdAsync(int id)
        {
            return await _dbSet.FirstAsync(p => p.IdEmpleado == id);
        }

        public async Task<Empleado>UpdateAsync(Empleado entity)
        {
            var empleado = await GetByIdAsync(entity.IdEmpleado);
            if (empleado == null)
            {
                return null;
            }
            empleado.NombreCompleto = entity.NombreCompleto;
            empleado.Correo = entity.Correo;
            empleado.Telefono = entity.Telefono;
            empleado.IdCargo = entity.IdCargo;



            await _context.SaveChangesAsync();
            return empleado;
        }
    }
}
