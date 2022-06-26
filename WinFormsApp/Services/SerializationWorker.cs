using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace WinFormsApp.Services
{
    class SerializationWorker
    {
        public void Serialize<TEntity>(TEntity obj, string jsonFileName)
        {
            var json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(jsonFileName, json);
        }

        public TEntity Deserialize<TEntity>(string fileName)
        {
            var json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<TEntity>(json);
        }
    }
}
