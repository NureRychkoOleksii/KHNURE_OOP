using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IdKey
    {
        Task<IEnumerable<TEntity>> GetAllAsync(string path);

        Task<TEntity> GetById(string path, int id);

        Task CreateObject(TEntity obj, string path);

        Task DeleteObject(TEntity obj, string path);
    }
}
