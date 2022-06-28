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

        public IEnumerable<TEntity> GetAllAsync(string path)
        {
            return _serializationWorker.Deserialize<IEnumerable<TEntity>>(path);
        }

        public TEntity GetById(string path, int id)
        {
            var res = GetAllAsync(path);
            return res.Where(user => user.Id == id).FirstOrDefault();
        }

        public void CreateObject(TEntity obj, string path)
        {
            _data = GetAllAsync(path).ToList();
            obj.Id = ++_data.OrderBy(x => x.Id).FirstOrDefault().Id;
            _data.Add(obj);
            _serializationWorker.Serialize<IEnumerable<TEntity>>(_data, path);
        }

        public void DeleteObject(TEntity obj, string path)
        {
            _data = _serializationWorker.Deserialize<IEnumerable<TEntity>>(path).ToList();
            _data.RemoveAll(x => x.Id == obj.Id);
            _serializationWorker.Serialize<IEnumerable<TEntity>>(_data, path);
        }
    }
}
