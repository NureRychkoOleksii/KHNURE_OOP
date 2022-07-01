using Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Services
{
    public class Repository<TEntity> where TEntity : IdKey
    {
        private readonly SerializationWorker _serializationWorker = new SerializationWorker();
        private List<TEntity> _data;

        public Repository()
        {
            _data = new List<TEntity>();
        }

        public IEnumerable<TEntity> GetAll(string path)
        {
            return _serializationWorker.Deserialize<IEnumerable<TEntity>>(path);
        }

        public TEntity GetById(string path, int id)
        {
            var res = GetAll(path);
            return res.Where(user => user.Id == id).FirstOrDefault();
        }

        public void CreateObject(TEntity obj, string path)
        {
            _data = GetAll(path).ToList();
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
