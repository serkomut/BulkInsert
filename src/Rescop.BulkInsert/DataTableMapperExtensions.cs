using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Rescop.BulkInsert
{
    public static class DataTableMapperExtensions
    {
        public static DataTable MapModel<T>(this IEnumerable<T> models, string tableName) where T : class, new()
        {
            if (models == null || !models.Any())
                return null;

            else
            {
                var dataTable = new DataTable(tableName);
                var infos = typeof(T).GetProperties().Where(p => p.GetCustomAttributes(typeof(FieldAttribute), true).Any());

                dataTable.CreateColumns(infos);

                models.FillData(dataTable, infos);

                dataTable.AcceptChanges();
                return dataTable;
            }
        }

        private static void FillData<T>(this IEnumerable<T> models, DataTable result, IEnumerable<PropertyInfo> infos) where T : class, new()
        {
            foreach (var model in models)
            {
                int matchCount = 0;
                var row = result.NewRow();
                foreach (PropertyInfo pi in infos)
                {
                    var attribute = pi.GetCustomAttributes(typeof(FieldAttribute), true).First() as FieldAttribute;
                    var value = pi.GetValue(model);
                    row[!string.IsNullOrWhiteSpace(attribute.ColumnName) ? attribute.ColumnName : pi.Name] = value;

                    if (value != null)
                        matchCount++;
                }
                if (matchCount > 0)
                    result.Rows.Add(row);
            }
        }

        private static void CreateColumns(this DataTable dataTable, IEnumerable<PropertyInfo> infos)
        {
            foreach (var pi in infos)
            {
                var attribute = pi.GetCustomAttributes(typeof(FieldAttribute), true).First() as FieldAttribute;
                if (!string.IsNullOrWhiteSpace(attribute.ColumnName))

                    dataTable.Columns.Add(attribute.ColumnName);
                else
                    dataTable.Columns.Add(pi.Name);
            }
        }
    }

}
