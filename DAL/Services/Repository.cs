using Core.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : IdKey
    {
        private readonly ISerializationWorker _serializationWorker;
        private List<TEntity> _data;

        public Repository(ISerializationWorker serializationWorker)
        {
            _serializationWorker = serializationWorker;
            _data = new List<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(string path)
        {
            return await _serializationWorker.Deserialize<IEnumerable<TEntity>>(path);
        }

        public async Task<TEntity> GetById(string path, int id)
        {
            var res = await GetAllAsync(path);
            return res.Where(user => user.Id == id).FirstOrDefault();
        }

        public async Task CreateObject(TEntity obj, string path)
        {
            _data = (await GetAllAsync(path)).ToList();
            obj.Id = ++_data.OrderBy(x => x.Id).FirstOrDefault().Id;
            _data.Add(obj);
            await _serializationWorker.Serialize<IEnumerable<TEntity>>(_data, path);
        }

        public async Task DeleteObject(TEntity obj, string path)
        {
            _data = (await _serializationWorker.Deserialize<IEnumerable<TEntity>>(path)).ToList();
            _data.RemoveAll(x => x.Id == obj.Id);
            await _serializationWorker.Serialize<IEnumerable<TEntity>>(_data, path);
        }
    }
}
