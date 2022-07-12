using System.IO;
using System.Threading.Tasks;
using DAL.Interfaces;
using Newtonsoft.Json;

namespace DAL.Services
{
    class SerializationWorker : ISerializationWorker
    {
        JsonSerializerSettings settings = new() { TypeNameHandling = TypeNameHandling.Auto };

        public void Serialize<TEntity>(TEntity obj, string jsonFileName)
        {
            var json = JsonConvert.SerializeObject(obj, settings);
            File.WriteAllText(jsonFileName, json);
        }

        public TEntity Deserialize<TEntity>(string fileName)
        {
            var json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<TEntity>(json, settings);
        }
    }
}
