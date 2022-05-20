using System;

namespace Rescop.BulkInsert
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FieldAttribute : Attribute
    {
        public string ColumnName { get; set; }
        public FieldAttribute(string columnName = null)
        {
            ColumnName = string.IsNullOrWhiteSpace(columnName) ? null : columnName;
        }
    }
}
