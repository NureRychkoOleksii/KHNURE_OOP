using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISerializationWorker
    {
        void Serialize<TEntity>(TEntity obj, string jsonFileName);
        TEntity Deserialize<TEntity>(string fileName);
    }
}