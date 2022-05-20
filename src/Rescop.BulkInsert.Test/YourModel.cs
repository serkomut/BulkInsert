using System;

namespace Rescop.BulkInsert.Test
{
    public class YourModel
    {
        [Field()]
        public Guid Id { get; set; }

        [Field("Definition")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Field("CreateDate")]
        public DateTime Date { get; set; }
    }
}
