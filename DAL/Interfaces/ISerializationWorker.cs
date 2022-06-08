using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISerializationWorker
    {
        Task Serialize<TEntity>(TEntity obj, string jsonFileName);
        Task<TEntity> Deserialize<TEntity>(string fileName);
    }
}