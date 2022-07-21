using System.IO;
using System.Threading.Tasks;
using DAL.Interfaces;
using Newtonsoft.Json;

namespace Core.Services
{
    class SerializationWorker : ISerializationWorker
    {
        private readonly JsonSerializerSettings _settings = new()
        {
            Formatting = Formatting.Indented
        };

        public void Serialize<TEntity>(TEntity obj, string jsonFileName)
        {
            var json = JsonConvert.SerializeObject(obj, _settings);
            File.WriteAllText(jsonFileName, json);
        }

        public TEntity Deserialize<TEntity>(string fileName)
        {
            var json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<TEntity>(json, _settings);
        }
    }
}
