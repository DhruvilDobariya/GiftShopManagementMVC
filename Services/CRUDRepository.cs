using GiftShopManagement.Data;
using GiftShopManagement.Insterfaces;
using Microsoft.EntityFrameworkCore;

namespace GiftShopManagement.Services
{
    public class CRUDRepository<T> : ICRUDRepository<T> where T : class
    {
        public string Message { get; set; }
        private readonly GiftShopContext _context;
        private readonly DbSet<T> _entities;

        public CRUDRepository(GiftShopContext context)
        {
            _context = context;
            _entities = _context.Set<T>();

        }

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                var entities = await _entities.ToListAsync();
                if (entities.Count == 0)
                {
                    Message = "Not Found";
                }
                return entities;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return null;
            }
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            try
            {
                var entity = await _entities.FindAsync(Id);
                if (entity == null)
                {
                    Message = "Not Found";
                }
                return entity;
            }
            catch (Exception ex)
            {
                Message = "Not Found";
                return null;
            }
        }

        public async Task<bool> InsertAsync(T entity)
        {
            try
            {
                if (entity == null)
                {
                    Message = "Entity is null";
                    return false;
                }
                await _entities.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;

            }
            catch(Exception ex)
            {
                if (ex.ToString().Contains("Violation of UNIQUE KEY constraint") || ex.ToString().Contains("Cannot insert duplicate key row in object"))
                {
                    Message = "This item already exist";
                    return false;
                }
                Message = ex.Message;
                return false;
            }

        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                if(entity == null)
                {
                    Message = "Entity is null";
                    return false;
                }
                _entities.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                if (ex.ToString().Contains("Violation of UNIQUE KEY constraint") || ex.ToString().Contains("Cannot insert duplicate key row in object"))
                {
                    Message = "This item already exist";
                    return false;
                }
                Message = ex.Message;
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            try
            {
                var entity = await _entities.FindAsync(Id);
                if (entity == null)
                {
                    Message = "Not Found";
                    return false;
                }
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    Message = "This item contain some record, so first you must delete these record, if you want to delete this item.";
                    return false;
                }
                Message = ex.Message;
                return false;
            }
        }
    }
}
