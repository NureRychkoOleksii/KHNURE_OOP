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
        IEnumerable<TEntity>GetAllAsync(string path);

        TEntity GetById(string path, int id);

        void CreateObject(TEntity obj, string path);

        void DeleteObject(TEntity obj, string path);
    }
}
