using Core.NewModels;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Methods
{
    public class MapService
    {
        private readonly Repository<Map> _repository = new Repository<Map>();
        private string _path = "Maps.json";

        public void AddMap(Map map)
        {
            _repository.CreateObject(map, _path);
        }

        public void AddNewMap(Map map)
        {
            _repository.CreateFirstObject(map, _path);
        }

        public Map? GetMapById(int id)
        {
            return _repository.GetById(_path, id);
        }

        public IEnumerable<Map> GetMaps()
        {
            return _repository.GetAll(_path);
        }

        public void UpdateMap(ref Map map, int id)
        {
            var userGet = _repository.GetById(_path, id);
            _repository.DeleteObject(userGet, _path);
            _repository.CreateObject(map, _path);
            map.Id = GetUserByName(map.Name).Id;
        }

        public Map GetUserByName(string name)
        {
            var res = GetMaps();
            return res.Where(user => user.Name == name).FirstOrDefault();
        }

    }
}
