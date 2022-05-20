using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Rescop.BulkInsert
{
    public class BulkRepostory : IBulkRepostory
    {
        private readonly SqlConnection connection;
        public BulkRepostory(SqlConnection connection)
        {
            this.connection = connection;
        }
        public Task BuklInsert<T>(IEnumerable<T> items) where T : class, new()
        {
            return BuklInsert(items, typeof(T).Name);
        }
        public async Task BuklInsert<T>(IEnumerable<T> items, string tableName) where T : class, new()
        {
            using (connection)
            {
                connection.Open();

                using (var bulkCopy = new SqlBulkCopy(connection.ConnectionString))
                {
                    bulkCopy.DestinationTableName = tableName;
                    bulkCopy.BulkCopyTimeout = 600;
                    await bulkCopy.WriteToServerAsync(items.MapModel(tableName));
                }
                connection.Close();
            }
        }
    }

}
