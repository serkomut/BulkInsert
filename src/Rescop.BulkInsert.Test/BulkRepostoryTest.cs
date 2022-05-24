using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Rescop.BulkInsert.Test
{
    [TestClass]
    public class BulkRepostoryTest
    {
        private readonly IBulkRepostory bulkRepostory;
        public BulkRepostoryTest()
        {
            var yourConnectionString = "";
            bulkRepostory = new BulkRepostory(new SqlConnection(yourConnectionString));
        }
        [TestMethod]
        public async void TestMethod1()
        {
            var datas = new List<YourModel>();
            for (int i = 0; i < 1000000; i++)
            {
                datas.Add(new YourModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Name",
                    Description = "Description",
                    Date = DateTime.Now
                });
            }
            await bulkRepostory.BuklInsert<YourModel>(datas);
        }
    }
}
