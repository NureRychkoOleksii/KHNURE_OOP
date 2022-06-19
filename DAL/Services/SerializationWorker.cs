using System.IO;
using System.Threading.Tasks;
using DAL.Interfaces;
using Newtonsoft.Json;

namespace DAL.Services
{
    class SerializationWorker : ISerializationWorker
    {
        public async Task Serialize<TEntity>(TEntity obj, string jsonFileName)
        {
            var json = JsonConvert.SerializeObject(obj);
            await File.WriteAllTextAsync(jsonFileName, json);
        }

        public async Task<TEntity> Deserialize<TEntity>(string fileName)
        {
            var json = await File.ReadAllTextAsync(fileName);
            return JsonConvert.DeserializeObject<TEntity>(json);
        }
    }
}
