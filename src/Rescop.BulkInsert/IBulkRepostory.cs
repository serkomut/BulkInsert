using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rescop.BulkInsert
{
    public interface IBulkRepostory
    {
        Task BuklInsert<T>(IEnumerable<T> items) where T : class, new();
        Task BuklInsert<T>(IEnumerable<T> items, string tableName) where T : class, new();
    }
}
