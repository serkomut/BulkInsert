# Rescop.BulkInsert

``` csharp
var datas = new List<YourModel>();
for (int i = 0; i < 100; i++)
{
    datas.Add(new YourModel
    {
        Id = Guid.NewGuid(),
        Name = "Name",
        Date = DateTime.now
    });
}

string connectionString = "Your ConnectionString";
var bulkRepostory = new BulkRepostory(new SqlConnection(connectionString));

await bulkRepostory.BuklInsert<YourModel>(datas);
```