using Alice.Backend.Data;
using Alice.Backend.Helpers;
using Alice.Backend.Repositories.Interfaces;
using Alice.Shared.DTOs;
using Alice.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Alice.Backend.Repositories.Implementations;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DataContext _context;
    private readonly DbSet<T> _entity;

    public GenericRepository(DataContext context)
    {
        _context = context;
        _entity = _context.Set<T>();
    }

    public virtual async Task<ActionResponse<T?>> AddAsync(T entity)
    {
        _context.Add(entity);
        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponse<T?>
            {
                IsSuccess = true,
                Message = "Entidad adicionada satisfactoriamente.",
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return DbUpdateExceptionActionResponse();
        }
        catch (Exception exception)
        {
            return ExceptionActionResponse(exception);
        }
    }

    public virtual async Task<ActionResponse<bool>> DeleteAsync(int id)
    {
        var row = await _entity.FindAsync(id);
        if (row == null)
        {
            return new ActionResponse<bool>
            {
                Message = "El registro no existe."
            };
        }
        _entity.Remove(row);

        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponse<bool>
            {
                IsSuccess = true
            };
        }
        catch (Exception)
        {
            return new ActionResponse<bool>
            {
                Message = "Ocurrió un error al intentar eliminar la entidad, porque tiene registros relacionados."
            };
        }
    }

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAllAsync() => new ActionResponse<IEnumerable<T>>
    {
        IsSuccess = true,
        Result = await _entity.ToListAsync()
    };

    public virtual async Task<ActionResponse<T?>> GetByIdAsync(int id)
    {
        var row = await _entity.FindAsync(id);
        if (row == null)
        {
            return new ActionResponse<T?>
            {
                Message = "Registro no existe."
            };
        }
        return new ActionResponse<T?>
        {
            IsSuccess = true,
            Result = row
        };
    }

    public virtual async Task<ActionResponse<T?>> UpdateAsync(int? id, T entity)
    {
        var existingEntity = await _context.Set<T>().FindAsync(id);
        if (existingEntity == null)
        {
            return new ActionResponse<T?>
            {
                Message = "La entidad no existe."
            };
        }

        _context.Entry(existingEntity).CurrentValues.SetValues(entity);

        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponse<T?>
            {
                IsSuccess = true,
                Message = "Entidad actualizada satisfactoriamente.",
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return DbUpdateExceptionActionResponse();
        }
        catch (Exception exception)
        {
            return ExceptionActionResponse(exception);
        }
    }

    private ActionResponse<T?> ExceptionActionResponse(Exception exception) => new ActionResponse<T?>
    {
        Message = $"Ocurrió un error inesperado. {exception.Message}"
    };

    private ActionResponse<T?> DbUpdateExceptionActionResponse() => new ActionResponse<T?>
    {
        Message = "El registro ya existe."
    };

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetPagedAsync(PaginationDTO pagination)
    {
        var queryable = _entity.AsQueryable();
        return new ActionResponse<IEnumerable<T>>
        {
            IsSuccess = true,
            Result = await queryable
                .Paginate(pagination)
                .ToListAsync()
        };
    }

    public virtual async Task<ActionResponse<int>> GetCountAsync(PaginationDTO pagination)
    {
        var queryable = _entity.AsQueryable();
        double count = await queryable.CountAsync();
        return new ActionResponse<int>
        {
            IsSuccess = true,
            Result = (int)count
        };
    }
}